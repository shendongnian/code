    X509Certificate2 cert =null;
    var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
    store.Open(OpenFlags.ReadOnly);
    X509Certificate2 cert =null;
    foreach (var certificate in store.Certificates)
    {
        if (certificate.Thumbprint=="ffffff")
            { cert = certificate; }
    }
    store.Close();
    var assertion = new Saml2Assertion(new Saml2NameIdentifier("Name"))
        .SigningCredentials = new X509SigningCredentials(cert);
    StringBuilder sb = new StringBuilder();
    var settings = new XmlWriterSettings();
    settings.OmitXmlDeclaration = true;
    settings.Indent = false;
    settings.Encoding = Encoding.UTF8;
    var stringWriter = new StringWriter(sb);
    var responseWriter = XmlWriter.Create(stringWriter, settings); 
    new Saml2Serializer().WriteSaml2Assertion(responseWriter, assertion);
    public class Saml2Serializer : Saml2SecurityTokenHandler
    {
        public Saml2Serializer()
        {
            Configuration = new SecurityTokenHandlerConfiguration()
            {};
        }
    public void WriteSaml2Assertion(XmlWriter writer, Saml2Assertion data)
    {
        try
        { base.WriteAssertion(writer, data); }
        catch (Exception e)
        { System.Console.Write(e.StackTrace); }      
    }
        public void WriteSaml2Token(XmlWriter writer, Saml2SecurityToken data)
        {
            try
            { base.WriteToken(writer, data); }
            catch (Exception e)
            { System.Console.Write(e.StackTrace); }
        }
    }
