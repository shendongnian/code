    Microsoft.SharePoint.Client.List list = clientContext.Web.Lists.GetByTitle("Main Folder");
    
    Microsoft.SharePoint.Client.CamlQuery caml = new Microsoft.SharePoint.Client.CamlQuery();
    
    caml.ViewXml = @"<View><Query><Where><Eq><FieldRef Name='FileLeafRef'/><Value Type='Folder'>SubFolderName</Value></Eq></Where></Query></View>";
    
    caml.FolderServerRelativeUrl = " This line should be added if the main folder is not in the site layer";
                        
    Microsoft.SharePoint.Client.ListItemCollection items = list.GetItems(caml);
    
    clientContext.Load(items);
    
    //Get your folder using items[0]
