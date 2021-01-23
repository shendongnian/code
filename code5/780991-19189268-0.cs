    [ServiceContract(CallbackContract = typeof(IServerFinishedProcessingCallback), SessionMode = SessionMode.Required)]
    public interface IDualMathService
    {
        [OperationContract(IsOneWay=true)]
        void ProcessAdd(double num1, double num2);
        [OperationContract(IsOneWay = true)]
        void ProcessSubtract(double num1, double num2);
        [OperationContract(IsOneWay=true)]
        void ProcessMultiply(double num1, double num2);
        [OperationContract(IsOneWay=true)]
        void ProcessDivide(double num1, double num2);
    }            
    public interface IServerFinishedProcessingCallback
    {        
        [OperationContract(IsOneWay=true)]
        void ProcessingFinished(string operation, double result);
    }
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class DualMathServiceClass : IDualMathService
    {
        readonly IServerFinishedProcessingCallback _clientCode = OperationContext.Current.GetCallbackChannel<IServerFinishedProcessingCallback>();
        //[PrincipalPermission()]
        public void ProcessAdd(double num1, double num2)
        {
            Console.WriteLine("Processing Request for client session ID " + OperationContext.Current.SessionId);
            Console.WriteLine(string.Format("Processing Add Request for parameters {0} and {1} ", num1, num2));
            _clientCode.ProcessingFinished("Add", (num1 + num2));
        }
        public void ProcessSubtract(double num1, double num2)
        {
            Console.WriteLine("Processing Request for client session ID " + OperationContext.Current.SessionId);
            Console.WriteLine(string.Format("Processing Subtract Request for parameters {0} and {1} ", num1, num2));
            _clientCode.ProcessingFinished("Subtract", (num1 - num2));
        }
        public void ProcessMultiply(double num1, double num2)
        {
            Console.WriteLine("Processing Request for client session ID " + OperationContext.Current.SessionId);
            Console.WriteLine(string.Format("Processing Multiply Request for parameters {0} and {1} ", num1, num2));
            _clientCode.ProcessingFinished("Multiply", (num1 * num2));
        }
        public void ProcessDivide(double num1, double num2)
        {
            Console.WriteLine("Processing Request for client session ID " + OperationContext.Current.SessionId);
            Console.WriteLine(string.Format("Processing Divide Request for parameters {0} and {1} ", num1, num2));
            if (num2 == 0)
                throw new FaultException<string>("Number 2 can not be zer");
            _clientCode.ProcessingFinished("Divide", (num1 / num2));
        }
    }
