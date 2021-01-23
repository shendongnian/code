     [TestMethod]
     public void CommonClientExecution()
     {
        List<ClientDetails> ListClientConfig = XmlSerialization.genericDeserializeFromXML(new     ClientDetails(), xmlFileRelativePath );
    
         foreach (var ClientDetails in ListClientConfig )
         {
           // you test logic here...
         }
    }
