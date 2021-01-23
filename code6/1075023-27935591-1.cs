    public class ResponseServiceHeader : ServiceHeader
    {
    }
    public ServiceHeader serviceHeader = null;
    public ResponseServiceHeader responseServiceHeader = null;
    [SoapHeader("serviceHeader", Direction = SoapHeaderDirection.Int)]
    [SoapHeader("responseServiceHeader", Direction = SoapHeaderDirection.Out)]
