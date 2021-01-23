    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        void MyMethod();
    }
	
    internal class MyService: IMyService
    {
        public void MyMethod()
        {
            Console.WriteLine("My Method");
            OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("headerFromMethod", "namespace", "headerFromMethodValue"));
        }
    }
	
