    ServiceMetadataBehavior smb = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
    // assume you found the ServiceMetadataBehavior... - you set new values
    smb.HttpGetEnabled = true;
    smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
    // and now you're ADDING the already existing "smb" to the behaviors collection!
    host.Description.Behaviors.Add(smb);
