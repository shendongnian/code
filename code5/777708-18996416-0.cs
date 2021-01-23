    using System.ServiceModel;
    using myNameSpace.joesWebService.WebAPI.SOAP;
    namespace myNameSpace
    {
        class Program
        {
            static void Main(string[] args)
            {
            // Create the binding
            BasicHttpBinding myBinding = new BasicHttpBinding();
            myBinding.MaxBufferSize = 256000000;
            myBinding.MaxReceivedMessageSize = 256000000;
            
            // Create the Channel Factory
            ChannelFactory<IjoesWebServer> factory =
                new ChannelFactory<IjoesWebServer>(myBinding, "http://joesWebServer/soap/IEntryPoint");
            // Create, use and close the client
            IjoesWebService client = null;
            string payloadXML = Loadpayload(filename);
            string response;
            try
            {
                client = ((ICommunicationObject)factory.CreateChannel()).Open();
                
                response = client.WebProcessShipment(string.Format("{0}@{1}", Username, Password), payloadXML);
                ((ICommunicationObject)client).Close();
            }
            catch (Exception ex)
            {
                ((ICommunicationObject)client).Abort();
 
                // Do something with the error (ex.Message) here
            }
        }
    }
