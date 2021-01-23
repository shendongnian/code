		public class MyOperationBehaviorAttribute : Attribute, IOperationBehavior
		{
			public void Validate(OperationDescription operationDescription)
			{
			}
			public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
			{
				if (dispatchOperation.Parent.MessageInspectors.OfType<MyMessageInspector>().Any() == false)
					dispatchOperation.Parent.MessageInspectors.Add(new MyMessageInspector());
			}
			public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
			{
			}
			public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
			{
			}
		}
