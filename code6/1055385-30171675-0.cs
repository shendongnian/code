    var newInformation =new Dictionary<PublishableContactInformationType, object>();
            newInformation.Add(PublishableContactInformationType.Availability, ContactAvailability.DoNotDisturb);
    try
    {
         this.lyncClient.Self.BeginPublishContactInformation(newInformation,(result) => this.lyncClient.Self.EndPublishContactInformation(result) , null);
    }  catch {}
