    using(var ctx = new ClientContext(webUrl))
    {     
       ctx.Credentials = new SharePointOnlineCredentials(userName,securePassword);
                
       var list = ctx.Web.Lists.GetByTitle(listTitle);
       var listItem = list.GetItemById(listItemId);             //get Folder item by Id
       var everyoneSecGroup = ctx.Web.SiteUsers.GetById(4);     //get Everyone security group            
       ShareListItem(listItem,everyoneSecGroup, "Read");
    }
