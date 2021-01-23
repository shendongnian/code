    using System;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;
    [ServiceContract(Namespace = "http://UE.ServiceModel.Samples")]
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
    [DataContract(Namespace = "http://someurl.temp")]
    public sealed class BusinessRuleFaultExceptionType
    {
    	[DataMember]
    	public int Code { get; set; }
    
    	[DataMember]
    	public string Reason { get; set; }
    }
