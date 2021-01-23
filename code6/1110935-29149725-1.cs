    //Find the last portion of the URI path
    var afterLastPathSepPos = uri.LastIndexOf('/', uri.Length - 2) + 1;
    var contractDesc = ContractDescription.GetContract(typeof(IGetStuff));
    foreach (var b in contractDesc.Operations[0].Behaviors)
    {
        var webInvokeAttr = b as WebInvokeAttribute;
        if (webInvokeAttr != null)
        {
            //Patch the URI template to use the last portion of the path
            webInvokeAttr.UriTemplate = uri.Substring(afterLastPathSepPos, uri.Length - afterLastPathSepPos);
            break;
        }
    }
    var endPoint = new ServiceEndpoint(contractDesc, new WebHttpBinding(), new EndpointAddress(uri.Substring(0, afterLastPathSepPos)));
    using (var wcf = new WebChannelFactory<I>(endPoint))
    {
        var intf = wcf.CreateChannel();
        var result = intf.GetStuff();   //Voila!
    }
