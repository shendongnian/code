    //config service metadata
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
   	   ServiceMetadataBehavior mb = new ServiceMetadataBehavior();
	   ServiceHost.Description.Behaviors.Add(mb);
	   
       if (bUseSSL) {
	    	mb.HttpsGetEnabled = true;
    		mb.HttpGetEnabled = false;
    		ServiceHost.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexHttpsBinding(), "mex");
    	} else {
     		mb.HttpsGetEnabled = false;
	    	mb.HttpGetEnabled = true;
    		ServiceHost.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
     	}
  
