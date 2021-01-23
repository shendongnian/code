	using System;
	using System.Diagnostics;
	using System.ServiceModel.Channels;
	using System.Collections.Generic;
	using System.ServiceModel.Description;
	using System.ServiceModel.Dispatcher;
	using System.Xml;
	/*
	 * This code was written based on the sample provided at http://msdn.microsoft.com/en-us/library/aa395223(v=vs.110).aspx. 
	 * The purpose of this is to allow dispatching of the incoming SOAP requests based on the payload XML element. 
	 * This allows the more standard document/literal service contract design to be used and does not rely on SOAP actions. 
	 */
	namespace OurOrganisation.Services.VendorIntegrationServices
	{
		class DispatchByBodyElementOperationSelector : IDispatchOperationSelector
		{
			Dictionary<XmlQualifiedName, string> dispatchDictionary;
			string defaultOperationName;
			public DispatchByBodyElementOperationSelector(Dictionary<XmlQualifiedName, string> dispatchDictionary, string defaultOperationName)
			{
				try
				{
					this.dispatchDictionary = dispatchDictionary;
					this.defaultOperationName = defaultOperationName;
				}
				catch (Exception ex)
				{
					Logger.Write(ex.Message);
					throw;
				}
			}
			#region IDispatchOperationSelector Members
			private Message CreateMessageCopy(Message message, XmlDictionaryReader body)
			{
				Message copy = Message.CreateMessage(message.Version, message.Headers.Action, body);
				copy.Headers.CopyHeaderFrom(message, 0);
				copy.Properties.CopyProperties(message.Properties);
				return copy;
			}
			public string SelectOperation(ref System.ServiceModel.Channels.Message message)
			{
				try
				{
					XmlDictionaryReader bodyReader = message.GetReaderAtBodyContents();
					XmlQualifiedName lookupQName = new XmlQualifiedName(bodyReader.LocalName, bodyReader.NamespaceURI);
					message = CreateMessageCopy(message, bodyReader);
					if (dispatchDictionary.ContainsKey(lookupQName))
					{
						return dispatchDictionary[lookupQName];
					}
					else
					{
						return defaultOperationName;
					}
				}
				catch (Exception ex)
				{
					Logger.Write(ex.Message);
					throw;
				}
				
			}
			#endregion
		}
		[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
		sealed class DispatchByBodyElementBehaviorAttribute : Attribute, IContractBehavior
		{
			#region IContractBehavior Members
			public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
			{
				// no binding parameters need to be set here
				return;
			}
			public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
			{
				// this is a dispatch-side behavior which doesn't require
				// any action on the client
				return;
			}
			public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.DispatchRuntime dispatchRuntime)
			{
				// We iterate over the operation descriptions in the contract and
				// try to locate an DispatchBodyElementAttribute behaviors on each 
				// operation. If found, we add the operation, keyed by QName of the body element 
				// that selects which calls shall be dispatched to this operation to a 
				// dictionary. 
				//Logger.Write("starting ApplyDispatchBehavior");
				try
				{
					Dictionary<XmlQualifiedName, string> dispatchDictionary = new Dictionary<XmlQualifiedName, string>();
					foreach (OperationDescription operationDescription in contractDescription.Operations)
					{
						DispatchBodyElementAttribute dispatchBodyElement =
							operationDescription.Behaviors.Find<DispatchBodyElementAttribute>();
						if (dispatchBodyElement != null)
						{
							dispatchDictionary.Add(dispatchBodyElement.QName, operationDescription.Name);
							//Logger.Write(string.Format("method {0} added", operationDescription.Name));
						}
					}
					// Lastly, we create and assign and instance of our operation selector that
					// gets the dispatch dictionary we've just created.
					dispatchRuntime.OperationSelector =
						new DispatchByBodyElementOperationSelector(
							dispatchDictionary,
							dispatchRuntime.UnhandledDispatchOperation.Name);
				}
				catch(Exception ex)
				{
					Logger.Write(ex.Message);
					throw;
				}
			}
			public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
			{
				// 
			}
			#endregion
		}
		[AttributeUsage(AttributeTargets.Method)]
		sealed class DispatchBodyElementAttribute : Attribute, IOperationBehavior
		{
			XmlQualifiedName qname;
			public DispatchBodyElementAttribute(string name)
			{
				qname = new XmlQualifiedName(name);
			}
			public DispatchBodyElementAttribute(string name, string ns)
			{
				qname = new XmlQualifiedName(name, ns);
			}
			internal XmlQualifiedName QName
			{
				get { return qname; }
				set { qname = value; }
			}
			#region IOperationBehavior Members
			public void AddBindingParameters(OperationDescription operationDescription, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
			{
			}
			public void ApplyClientBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.ClientOperation clientOperation)
			{
			}
			public void ApplyDispatchBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.DispatchOperation dispatchOperation)
			{
			}
			public void Validate(OperationDescription operationDescription)
			{
			}
			#endregion
		}
		internal class Logger
		{
			public static void Write(string message)
			{
				string sSource;
				string sLog;
				string sEvent;
				sSource = "MAL dispatch by body extension";
				sLog = "Application";
				sEvent = message;
				if (!EventLog.SourceExists(sSource))
					EventLog.CreateEventSource(sSource, sLog);
				EventLog.WriteEntry(sSource, sEvent);
			}
		}
	}
