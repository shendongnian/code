    static void Main(string[] args)
    {
        
        try
        {
            System.ServiceModel.BasicHttpBinding MyHttpBinding = new System.ServiceModel.BasicHttpBinding(System.ServiceModel.BasicHttpSecurityMode.TransportCredentialOnly);                                            
            MyHttpBinding.Security.Transport.ClientCredentialType = System.ServiceModel.HttpClientCredentialType.Windows;
            //MyHttpBinding.Security.Transport.ClientCredentialType = System.ServiceModel.HttpClientCredentialType.Ntlm;  //works too
            System.ServiceModel.EndpointAddress MyAuthASMXWebServiceAddress = new System.ServiceModel.EndpointAddress(new Uri("http://localhost/TestWS.asmx"));
            TWS.TestWSSoapClient svc = new TWS.TestWSSoapClient(MyHttpBinding, MyAuthASMXWebServiceAddress);
         
            Console.WriteLine(svc.HelloWorld());
        }
        catch (Exception err)
        {
            Console.WriteLine(err.ToString());
        }
        finally
        {
            Console.ReadLine();
        }
    }
