    public class Service1 :IService1
         {   
                   public string putData(Stream data)
                    {
                       try
                       {
                           //reading headers
                           IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
                           WebHeaderCollection headers = request.Headers;
                           foreach (string headerName in headers.AllKeys)
                           {
                                Console.WriteLine(headerName + ": " + headers[headerName]);
                           }
    
                           //---- rest of the code
                       }
                       catch (Exception ex)
                       {
                          return "Failed";
                       }
                    }
          }
