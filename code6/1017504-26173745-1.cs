    explorer = OutlookApp.ActiveExplorer();
            // response = explorer.ActiveInlineResponse;
            response = explorer.GetType().InvokeMember("ActiveInlineResponse",
                                 System.Reflection.BindingFlags.GetProperty | 
                                 System.Reflection.BindingFlags.Instance |
                                 System.Reflection.BindingFlags.Public, 
                                 null, explorer, null) as Outlook.MailItem;
