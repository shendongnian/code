    Boolean hasShownMessage = false;
    foreach (XDocument document in transmissionBuilder)
    {
      // On catch change it
      catch (Exception e)
            {
                if (!hasShownMessage)
                 {
                   Utilities.LogError((long)transmissionBuilder.CurrentApplicantId, e.Message + e.StackTrace);
                Utilities.WriteToFile(e.Message + "-----" + e.StackTrace);
                lblMessage.Text = "Error while connecting with ACE Server.  Retrying...";
                }
               hasShownMessage = True; // Set the flag to True
            }
    }
