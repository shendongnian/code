    using System.ServiceModel;
    // other usings, namespace etc
    [ServiceContract(Namespace = "http://websrv.cs.fsu.edu/~engelen/calc.wsdl", Name = "calc")]
    public interface ICalcService
    {
        [OperationContract(Name = "add")]
        [return: MessageParameter(Name = "result")]
        [XmlSerializerFormatAttribute(Style=OperationFormatStyle.Rpc, Use=OperationFormatUse.Encoded)]
        double add(double a, double b);
        // the rest of methods
    }
