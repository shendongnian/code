    [ServiceContract(Namespace = "http://Foo.bar.car")]
    public interface IPolicyService
    {
        [OperationContract]
        PolicyResponse GetPolicyData(PolicyRequest request);
    }
    
    public class PolicyData : IPolicyService
    {
       public PolicyResponse GetPolicyData(PolicyRequest request)
       {
                var polNbr = request.REQ_POL_NBR;
                return GetMyData(polNbr);
        }
    }
