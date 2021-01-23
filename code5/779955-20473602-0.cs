    Uri hostWeb = new Uri(Request.QueryString["SPHostUrl"]);
            List<string> listOfUsers = new List<string>();
            using (var clientContext = TokenHelper.GetS2SClientContextWithWindowsIdentity(hostWeb, Request.LogonUserIdentity))
            {
                List oList = clientContext.Web.Lists.GetByTitle("TestList");
                CamlQuery camlQuery = new CamlQuery();
                camlQuery.ViewXml = "<View><Query><Where><Geq><FieldRef Name='ID'/>" +
                    "<Value Type='Number'>0</Value></Geq></Where></Query><RowLimit>100</RowLimit></View>";
                Microsoft.SharePoint.Client.ListItemCollection collListItem = oList.GetItems(camlQuery);
                clientContext.Load(collListItem);
                clientContext.ExecuteQuery();
                foreach (Microsoft.SharePoint.Client.ListItem oListItem in collListItem)
                {
                    listview.Add(string.Format("ID: {0} \nTitle: {1}", oListItem.Id, oListItem["Title"]));
                }
                ListList.DataSource = listOfUsers;
                ListList.DataBind();
            }
