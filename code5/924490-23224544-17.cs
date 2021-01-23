    [ServiceContract(Namespace = "http://UE.ServiceModel.Samples")]
    [XmlSerializerFormat(SupportFaults = true)]
    public interface ICalculator
    {
    	[OperationContract(IsOneWay = false)]
    	[FaultContract(typeof(BusinessRuleFaultExceptionType))]
    	double Add(double n1, double n2);
    
    	[OperationContract(IsOneWay = false)]
    	[FaultContract(typeof(BusinessRuleFaultExceptionType))]
    	double Subtract(double n1, double n2);
    
    	[OperationContract(IsOneWay = false)]
    	[FaultContract(typeof(BusinessRuleFaultExceptionType))]
    	double Multiply(double n1, double n2);
    
    	[OperationContract(IsOneWay = false)]
    	[FaultContract(typeof(BusinessRuleFaultExceptionType))]
    	double Divide(double n1, double n2);
    }
    
    /// <summary>
    /// General fault structure. 
    /// </summary>
    [DataContract(Name = "BusinessRuleFaultExceptionType", Namespace = "http://someurl.temp")]
    [XmlType("BusinessRuleFaultExceptionType", Namespace = "http://someurl.temp")]
    public sealed class BusinessRuleFaultExceptionType
    {
    	//[DataMember]
    	[XmlElement(IsNullable = false,Namespace = "http://namespaces2.url")]
    	public int Code { get; set; }
    
    	[XmlElement(IsNullable = false, Namespace = "http://namespaces2.url")]
    	public string Reason { get; set; }
    }
    
    [ErrorBehavior(typeof(MyErrorHandler))]
    public class CalculatorService : ICalculator
    {
    	public double Add(double n1, double n2)
    	{
    		double result = n1 + n2;
    		Console.WriteLine("Received Add({0},{1})", n1, n2);
    		Console.WriteLine("Return: {0}", result);
    
    		throw new FaultException<BusinessRuleFaultExceptionType>(new BusinessRuleFaultExceptionType()
    		{
    			Code = -100,
    			Reason = "xxx"
    		});
    		//throw new ArgumentException("My exception");
    		return result;
    	}
    
    	public double Subtract(double n1, double n2)
    	{
    		double result = n1 - n2;
    		Console.WriteLine("Received Subtract({0},{1})", n1, n2);
    		Console.WriteLine("Return: {0}", result);
    		return result;
    	}
    
    	public double Multiply(double n1, double n2)
    	{
    		double result = n1 * n2;
    		Console.WriteLine("Received Multiply({0},{1})", n1, n2);
    		Console.WriteLine("Return: {0}", result);
    		return result;
    	}
    
    	public double Divide(double n1, double n2)
    	{
    		double result = n1 / n2;
    		Console.WriteLine("Received Divide({0},{1})", n1, n2);
    		Console.WriteLine("Return: {0}", result);
    		return result;
    	}
    }
