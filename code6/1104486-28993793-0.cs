    Public Void UpdateColumnsForOnlyOneFolder(maildId1,mailId2){
                   ClientContext ctx = new ClientContext("http://mytestsite/");
                    List list = ctx.Web.Lists.GetByTitle("User Details");
    	        CamlQuery spQuery = CamlQuery.CreateAllItemsQuery();
                    spQuery.FolderServerRelativeUrl = "Enter Relative URL TO FOLDER"  // Example "/managedpath/site/Lists/listname/Folder Name"
                    Microsoft.SharePoint.Client.ListItemCollection items = list.GetItems(spQuery);
                    ctx.Load(items); 
                    ctx.ExecuteQuery();
                    foreach (Microsoft.SharePoint.Client.ListItem item in items)
                    {
                        item["email1"] = mailId1;              
                        item["email2"] = mailId2;              
                        item.Update();
                    }
                    ctx.ExecuteQuery(); 
    }
