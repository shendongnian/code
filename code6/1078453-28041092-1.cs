        /// <summary>
        /// IInterceptionBehavior that will request a new channel from a ChannelFactory for each call,
        /// and close (or abort) it after each call.
        /// </summary>
        /// <typeparam name="T">business interface of SOAP service to call</typeparam>
        public class SoapClientInterceptorBehavior<T> : IInterceptionBehavior 
        {
            // create a logger to include the interface name, so we can configure log level per interface
            // Warn only logs exceptions (with arguments)
            // Info can be enabled to get overview (and only arguments on exception),
            // Debug always provides arguments and Trace also provides return value
            private static readonly Logger Logger = LogManager.GetLogger(LoggerName());
        private static string LoggerName()
        {
            string baseName = MethodBase.GetCurrentMethod().DeclaringType.FullName;
            baseName = baseName.Remove(baseName.IndexOf('`'));
            return baseName + "." + typeof(T).Name;
        }
        private readonly Func<T> _clientCreator;
        /// <summary>
        /// Creates new, using channelFactory.CreatChannel to create a channel to the SOAP service.
        /// </summary>
        /// <param name="channelFactory">channelfactory to obtain connections from</param>
        public SoapClientInterceptorBehavior(ChannelFactory<T> channelFactory)
                    : this(channelFactory.CreateChannel)
        {
        }
        /// <summary>
        /// Creates new, using the supplied method to obtain a connection per call.
        /// </summary>
        /// <param name="clientCreationFunc">delegate to obtain client connection from</param>
        public SoapClientInterceptorBehavior(Func<T> clientCreationFunc)
        {
            _clientCreator = clientCreationFunc;
        }
        /// <summary>
        /// Intercepts calls to SOAP service, ensuring proper creation and closing of communication
        /// channel.
        /// </summary>
        /// <param name="input">invocation being intercepted.</param>
        /// <param name="getNext">next interceptor in chain (will not be called)</param>
        /// <returns>result from SOAP call</returns>
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Logger.Info(() => "Invoking method: " + input.MethodBase.Name + "()");
            // we will not invoke an actual target, or call next interception behaviors, instead we will
            // create a new client, call it, close it if it is a channel, and return its
            // return value.
            T client = _clientCreator.Invoke();
            Logger.Trace(() => "Created client");
            var channel = client as IClientChannel;
            IMethodReturn result;
            int size = input.Arguments.Count;
            var args = new object[size];
            for(int i = 0; i < size; i++)
            {
                args[i] = input.Arguments[i];
            }
            Logger.Trace(() => "Arguments: " + string.Join(", ", args));
            try
            {
                object val = input.MethodBase.Invoke(client, args);
                if (Logger.IsTraceEnabled)
                {
                    Logger.Trace(() => "Completed " + input.MethodBase.Name + "(" + string.Join(", ", args) + ") return-value: " + val);
                }
                else if (Logger.IsDebugEnabled)
                {
                    Logger.Debug(() => "Completed " + input.MethodBase.Name + "(" + string.Join(", ", args) + ")");
                }
                else
                {
                    Logger.Info(() => "Completed " + input.MethodBase.Name + "()");
                }
                result = input.CreateMethodReturn(val, args);
                if (channel != null)
                {
                    Logger.Trace("Closing channel");
                    channel.Close();
                }
            }
            catch (TargetInvocationException tie)
            {
                // remove extra layer of exception added by reflective usage
                result = HandleException(input, args, tie.InnerException, channel);
            }
            catch (Exception e)
            {
                result = HandleException(input, args, e, channel);
            }
            return result;
        }
        private static IMethodReturn HandleException(IMethodInvocation input, object[] args, Exception e, IClientChannel channel)
        {
            if (Logger.IsWarnEnabled)
            {
                // we log at Warn, caller might handle this without need to log
                string msg = string.Format("Exception from " + input.MethodBase.Name + "(" + string.Join(", ", args) + ")");
                Logger.Warn(msg, e);
            }
            IMethodReturn result = input.CreateExceptionMethodReturn(e);
            if (channel != null)
            {
                Logger.Trace("Aborting channel");
                channel.Abort();
            }
            return result;
        }
        /// <summary>
        /// Returns the interfaces required by the behavior for the objects it intercepts.
        /// </summary>
        /// <returns>
        /// The required interfaces.
        /// </returns>
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return new [] { typeof(T) };
        }
        /// <summary>
        /// Returns a flag indicating if this behavior will actually do anything when invoked.
        /// </summary>
        /// <remarks>
        /// This is used to optimize interception. If the behaviors won't actually
        ///             do anything (for example, PIAB where no policies match) then the interception
        ///             mechanism can be skipped completely.
        /// </remarks>
        public bool WillExecute
        {
            get { return true; }
        }
        /// <summary>
        /// Creates new client, that will obtain a fresh connection before each call
        /// and closes the channel after each call.
        /// </summary>
        /// <param name="factory">channel factory to connect to service</param>
        /// <returns>instance which will have SoapClientInterceptorBehavior applied</returns>
        public static T CreateInstance(ChannelFactory<T> factory)
        {
            IInterceptionBehavior behavior = new SoapClientInterceptorBehavior<T>(factory);
            return (T)Intercept.ThroughProxy<IMy>(
                      new MyClass(),
                      new InterfaceInterceptor(),
                      new[] { behavior });
        }
        /// <summary>
        /// Dummy class to use as target (which will never be called, as this behavior will not delegate to it).
        /// Unity Interception does not allow ONLY interceptor, it needs a target instance
        /// which must implement at least one public interface.
        /// </summary>
        public class MyClass : IMy
        {
        }
        /// <summary>
        /// Public interface for dummy target.
        /// Unity Interception does not allow ONLY interceptor, it needs a target instance
        /// which must implement at least one public interface.
        /// </summary>
        public interface IMy
        {
        }
    }
