    using (Microsoft.Web.Administration.ServerManager sm = Microsoft.Web.Administration.ServerManager.OpenRemote(serverName))
    {
       foreach(var server in checkedListBox1.CheckedItems)
       {
          try
          {
            Microsoft.Web.Administration.Site site = sm.Sites.Where(q => q.Name.Equals(server.ToString())).FirstOrDefault();      
            site.Stop();
            showStatus(siteName);
          }
          catch(Exception e) { /*handle*/ }
       }
    }
