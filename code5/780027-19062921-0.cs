     catch (System.ServiceModel.FaultException FaultEx)
      {
       //Gets the Detail Element in the
       string ErrorMessage;
       System.ServiceModel.Channels.MessageFault mfault = FaultEx.CreateMessageFault();
       if (mfault.HasDetail)
         ErrorMessage = mfault.GetDetail<System.Xml.XmlElement>().InnerText;
      } 
