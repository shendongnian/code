    try
    {
     WcfEx.IwcfS5ExtensionClient client = new IwcfS5ExtensionClient("MyEndpointConfigurationName");
     client.Open();
     if (client.State == CommunicationState.Opened)
     {
         //change UI to Connected
     }
     else
     {
         //change ui to Connection Error
     }
     Application.DoEvents();
     //Change UI to Transfering data
     Application.DoEvents();
     client.DoWork();
     //change UI to transfer done
     Application.DoEvents();
     client.Close();
     //change ui to Closed
    }
    catch (Exception e)
    {
       //change ui to Comunication error
    }
