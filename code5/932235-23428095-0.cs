    System.ServiceModel.Channels.MessageFault mf = ex.CreateMessageFault();
    if (mf.HasDetail) {
        System.Xml.XmlElement detailedMessage = mf.GetDetail<System.Xml.XmlElement>();
        System.Diagnostics.Trace.WriteLine("Detail: " + detailedMessage.InnerText);
    }
