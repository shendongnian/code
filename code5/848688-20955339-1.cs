    [ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]
    public interface ICalculator
    {
        //... (Snip) ...
        [OperationContract]
        [FaultContract(typeof(MathFault))]
        int Divide(int n1, int n2);
    }
    [DataContract(Namespace="http://Microsoft.ServiceModel.Samples")]
    public class MathFault
    {    
        private string operation;
        private string problemType;
    
        [DataMember]
        public string Operation
        {
            get { return operation; }
            set { operation = value; }
        }
    
        [DataMember]        
        public string ProblemType
        {
            get { return problemType; }
            set { problemType = value; }
        }
    }
    //Server side function
    public int Divide(int n1, int n2)
    {
        try
        {
            return n1 / n2;
        }
        catch (DivideByZeroException)
        {
            MathFault mf = new MathFault();
            mf.operation = "division";
            mf.problemType = "divide by zero";
            throw new FaultException<MathFault>(mf);
        }
    }
