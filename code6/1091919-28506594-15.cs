		public class MyOperationBehaviorAttribute : Attribute, IOperationBehavior
		{
			public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
			{
				if (dispatchOperation.Parent.MessageInspectors.OfType<MyMessageInspector>().Any() == false)
					dispatchOperation.Parent.MessageInspectors.Add(new MyMessageInspector());
			}
			[...]
		}
