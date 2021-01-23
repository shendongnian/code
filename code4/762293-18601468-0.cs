    public interface IWSDLProvider
    {
       string GetWsdlFromService(string url);
    }
    
    public class MyWsdlProvider : IWSDLProvider
    {
       private readonly IWebWrapper _webCLient;
    
       public MyWsdlProvider(IwebWrapper webClient)
       {
           _webClient = webCLient;
       }
    
       public string GetWsdlFromService(string url)
       {
          //do here whatever is needed with the webClient to get the wsdl
       }
    }
    
    public interface IWSDLParser
    {
       MyServiceData GetServiceDataFromUrl(string url);
    }
    
    public class MyWsdlParser : IWSDLParser
    {
       private readonly IWSDLProvider _wsdlProvider;
       public MyWsdlParser(IWSDLProvider wsdlProvider)
       {
          _wsdlProvider = wsdlProvider;
       }
    
       public MyServiceData GetServiceDataFromUrl(string url)
       {
          //use the wsdl provder to fetch the wsdl
          //and then parse it
       }
    }
