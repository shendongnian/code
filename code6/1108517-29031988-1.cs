    string sDefaultNamespace = "urn:veloconnect:profile-1.1";
    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
    ns.Add("", sDefaultNamespace);
    
    XmlSerializer serialize = new XmlSerializer(ResponseResult.GetType(), sDefaultNamespace);
    serialize.Serialize(Response.OutputStream, ResponseResult, ns);
