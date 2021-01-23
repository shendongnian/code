    using System;
    using Microsoft.SharePoint.Client;
    using SP = Microsoft.SharePoint.Client;
    
    namespace Microsoft.SDK.SharePointServices.Samples
    {
        class CreateListItem
        {
            static void Main()
            {   
                string siteUrl = "http://MyServer/sites/MySiteCollection";
    
                ClientContext clientContext = new ClientContext(siteUrl);
                SP.List oList = clientContext.Web.Lists.GetByTitle("Announcements");
    
                ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
                ListItem oListItem = oList.AddItem(itemCreateInfo);
                oListItem["Title"] = "My New Item!";
                oListItem["Body"] = "Hello World!";
    
                oListItem.Update();
    
                clientContext.ExecuteQuery(); 
            }
        }
    }
