    [ServiceContract(CallbackContract=typeof(IConsoleCallback))]
    public interface IService1
    {
        [OperationContract(IsOneWay = true)]
        void Display(string[] arr);
    }
    public interface IConsoleCallback
    {
        [OperationContract(IsOneWay = true)]
        void WriteLine(string message);
    }
    public class Service1 : IService1
    {
        public void Display(string[] arr)
        {
            var callback = OperationContext.Current.GetCallbackChannel<IConsoleCallback>();
            for (int i = 0; i < arr.Length; i++)
            {
                callback.WriteLine(arr[i]);
            }
        }
    }
