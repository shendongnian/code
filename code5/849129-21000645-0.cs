    [System.Web.Services.WebServiceAttribute(Namespace="http://websrv.cs.fsu.edu/~engelen/calc.wsdl")]
    [System.Web.Services.WebServiceBinding(Name="calc", Namespace="http://websrv.cs.fsu.edu/~engelen/calc.wsdl")]
    public abstract partial class calc : System.Web.Services.WebService {
    /// <remarks>
    ///Service definition of function ns__add
    ///</remarks>
    [System.Web.Services.WebMethodAttribute()]
    [System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace="urn:calc", ResponseNamespace="urn:calc")]
    [return: System.Xml.Serialization.SoapElement("result")]
    public abstract double add(double a, double b); 
