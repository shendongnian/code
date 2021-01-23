    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace WcfErrorResponse
    {
        /// <summary>
        /// Provides a base IOperationInvoker implementation that stores and passes through calls to the exisiting (old) invoker
        /// </summary>
        public abstract class InvokerBase : IOperationInvoker
        {
            private readonly IOperationInvoker m_OldInvoker;
    
            protected IOperationInvoker OldInvoker
            {
                get { return m_OldInvoker; }
            }
    
            public InvokerBase(IOperationInvoker oldInvoker)
            {
                m_OldInvoker = oldInvoker;
            }
    
            public virtual object[] AllocateInputs()
            {
                return OldInvoker.AllocateInputs();
            }
    
            public virtual object Invoke(object instance, object[] inputs, out object[] outputs)
            {
                return OldInvoker.Invoke(instance, inputs, out outputs);
            }
    
            public virtual IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
            {
                return OldInvoker.InvokeBegin(instance, inputs, callback, state);
            }
    
            public virtual object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
            {
                return OldInvoker.InvokeEnd(instance, out outputs, result);
            }
    
            public virtual bool IsSynchronous
            {
                get { return OldInvoker.IsSynchronous; }
            }
        }
    
        /// <summary>
        /// Base implementation for a Method level attribte that applies a <see cref="InvokerBase"/> inherited behavior.
        /// </summary>
        [AttributeUsage(AttributeTargets.Method)]
        public abstract class InvokerOperationBehaviorAttribute : Attribute, IOperationBehavior
        {
            protected abstract InvokerBase CreateInvoker(IOperationInvoker oldInvoker, OperationDescription operationDescription, DispatchOperation dispatchOperation);
    
            public void AddBindingParameters(OperationDescription operationDescription, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
            { }
    
            public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
            { }
    
            public virtual void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
            {
                // chain invokers.
                IOperationInvoker oldInvoker = dispatchOperation.Invoker;
                dispatchOperation.Invoker = CreateInvoker(oldInvoker, operationDescription, dispatchOperation);
            }
    
            public virtual void Validate(OperationDescription operationDescription)
            {
                return;
            }
        }
    
        public class ResponseExceptionInvoker : InvokerBase
        {
            private Type returnType;
    
            public ResponseExceptionInvoker(IOperationInvoker oldInvoker, OperationDescription operationDescription)
                : base(oldInvoker)
            {
                // save the return type for creating response messages
                this.returnType = operationDescription.GetReturnType();
    
                if (this.returnType == null)
                {
                    throw new InvalidOperationException("The operation '" + operationDescription.SyncMethod.DeclaringType.Name + "' does not define a return type.");
                }
            }
    
            public override object Invoke(object instance, object[] inputs, out object[] outputs)
            {
                object returnedValue = null;
                object[] outputParams = new object[] { };
                outputs = new object[] { };
    
                try
                {
                    returnedValue = OldInvoker.Invoke(instance, inputs, out outputParams);
                    outputs = outputParams;
                    return returnedValue;
                }
                catch (Exception ex)
                {
                    Logger.Debug("ResponseExceptionInvoker() - Caught Exception. A Response Message will be returned. Message='" + ex.Message + "'");
    
                    // there was an excpetion. Do not assign output params... their state is undefined.
                    //outputs = outputParams;
    
                    try
                    {
                        // assumes the behavior only used for return types that inherit from Response, as verified by ResponseExceptionOperationBehaviorAttribute.Validate()
                        Response response = (Response)Activator.CreateInstance(this.returnType);
                        response.Success = false;
                        response.ErrorMessage = ex.Message;
                        return response;
                    }
                    catch (Exception exCreateResponse)
                    {
                        // Log that the Response couldn't be created and throw the original exception.
                        // Probably preferable to wrap and throw.
                        Logger.Error("Caught ResponseException, but unable to create the Response object. Likely indicates a bug or misconfiguration. Exception will be rethrown." + exCreateResponse.Message);
                    }
    
                    throw;
                }
            }
        }
    
        public class ResponseExceptionOperationBehaviorAttribute : InvokerOperationBehaviorAttribute
        {
            protected override InvokerBase CreateInvoker(IOperationInvoker oldInvoker, OperationDescription operationDescription, DispatchOperation dispatchOperation)
            {
                return new ResponseExceptionInvoker(oldInvoker, operationDescription);
            }
    
            public override void Validate(OperationDescription operationDescription)
            {
                // validate that this attribute can be applied to the service behavior.
                Type returnType = operationDescription.GetReturnType();
                if (!typeof(Response).IsAssignableFrom(returnType))
                {
                    throw new InvalidOperationException("'" + returnType.FullName + "' does not inherit from '" + typeof(Response).FullName +
                                                        "'. ImplicitResponse behavior applied to '" + operationDescription.SyncMethod.DeclaringType.Name + "." + operationDescription.Name +
                                                        "' requires the method return type inherit from '" + typeof(Response).FullName);
                }
            }
        }
    
        static class OperationDescriptionExtensions
        {
            public static Type GetReturnType(this OperationDescription operationDescription)
            {
                if (operationDescription.SyncMethod == null)
                    throw new InvalidOperationException("These behaviors have only been tested with Sychronous methods.");
    
                // !! Warning: This does NOT work for Asynch or Task based implementations.
                System.Reflection.MethodInfo method = operationDescription.SyncMethod ?? operationDescription.EndMethod;
                return method.ReturnType;
            }
        }
    
        // When not using FaultContracts, return success/fail as a part of all responses via some base class properties.
        [DataContract]
        public class Response
        {
            [DataMember]
            public bool Success { get; set; }
    
            [DataMember]
            public string ErrorMessage { get; set; }
        }
    
        public class ChildResponse : Response
        {
            [DataMember]
            public string Foo { get; set; }
        }
    
        [DataContract]
        public class Request
        {
            [DataMember]
            public string Name { get; set; }
        }
    
        [ServiceContract]
        public interface ISimple
        {
            [OperationContract]
            ChildResponse Work(Request request);
    
            [OperationContract]
            ChildResponse Fail(Request request);
        }
    
        public class SimpleService : ISimple
        {
            public ChildResponse Work(Request request) {
                return new ChildResponse() { Success = true };
            }
    
            [ResponseExceptionOperationBehavior]
            public ChildResponse Fail(Request request)
            {
                throw new NotImplementedException("This method isn't done");
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                ServiceHost simpleHost = new ServiceHost(typeof(SimpleService), new Uri("http://localhost/Simple"));
                simpleHost.Open();
    
                ChannelFactory<ISimple> factory = new ChannelFactory<ISimple>(simpleHost.Description.Endpoints[0]);
                ISimple proxy = factory.CreateChannel();
    
                Logger.Debug("Calling Work...");
                var response1 = proxy.Work(new Request() { Name = "Foo" });
                Logger.Debug("Work() returned Success=" + response1.Success + " message='" + response1.ErrorMessage + "'");
    
                Logger.Debug("Calling Fail...");
                var response2 = proxy.Fail(new Request() { Name = "FooBar" });
                Logger.Debug("Fail() returned Success=" + response2.Success + " message='" + response2.ErrorMessage + "'");
    
                Console.WriteLine("Press ENTER to close the host.");
                Console.ReadLine();
    
                ((ICommunicationObject)proxy).Shutdown();
    
                simpleHost.Shutdown();
            }
        }
    
    
        public static class CommunicationObjectExtensions
        {
            static public void Shutdown(this ICommunicationObject obj)
            {
                try
                {
                    obj.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Shutdown exception: {0}", ex.Message);
                    obj.Abort();
                }
            }
        }
    
        public static class Logger
        {
            public static void Debug(string message) { Console.WriteLine(message); }
    
            public static void Error(string message) { Console.WriteLine(message); }
        }
    }
