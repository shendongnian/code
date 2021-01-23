         List<Application> appsToRemove = new List<Application>();
         for (int i = 0; i < manager.Sites[siteName].Applications.Count; i++)
         {
            if (manager.Sites[siteName].Applications[i].Path != "/")
            {
               Console.WriteLine("Removing {0}", manager.Sites[siteName].Applications[i].Path);
               appsToRemove.Add(manager.Sites[siteName].Applications[i]);
            }
         }
         foreach (Application a in appsToRemove)
         {
            manager.Sites[siteName].Applications.Remove(a);
         }
         manager.CommitChanges();
