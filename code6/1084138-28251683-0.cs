    using System.Runtime.InteropServices; 
    // ... 
    private void ShowUserProperties(Outlook.MailItem mail) 
    {
       Outlook.UserProperties mailUserProperties = null; 
       Outlook.UserProperty mailUserProperty = null; 
       StringBuilder builder = new StringBuilder(); 
       mailUserProperties = mail.UserProperties; 
       try 
       { 
           for (int i = 1; i < = mailUserProperties.Count; i++) 
           { 
               mailUserProperty = mailUserProperties[i]; 
               if (mailUserProperty != null) 
               { 
                   builder.AppendFormat("Name: {0} \tValue: {1} \n\r", 
                      mailUserProperty.Name, mailUserProperty.Value); 
                   Marshal.ReleaseComObject(mailUserProperty); 
                   mailUserProperty = null; 
               } 
           } 
           if (builder.Length > 0) 
           { 
              System.Windows.Forms.MessageBox.Show(builder.ToString(), 
                   "The UserProperties collection"); 
           } 
        } 
        catch (Exception ex) 
        { 
           System.Windows.Forms.MessageBox.Show(ex.Message); 
        } 
        finally 
        { 
           if (mailUserProperties != null) 
               Marshal.ReleaseComObject(mailUserProperties); 
        } 
     }
   
