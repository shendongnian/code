    ServiceMetadataBehavior smb = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
    // If not, create new one, set values, add to collection
    if (smb == null)
    {
       smb = new ServiceMetadataBehavior();
       smb.HttpGetEnabled = true;
       smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
       // add to behaviors collection
       host.Description.Behaviors.Add(smb);
       // add service endpoint
       host.AddServiceEndpoint(
              ServiceMetadataBehavior.MexContractName,
              MetadataExchangeBindings.CreateMexHttpBinding(),
              "mex"
       );
    }
