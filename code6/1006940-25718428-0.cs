    using (SPSite site = new SPSite("URL")
         {
            using (SPWeb web = site.OpenWeb("sitecollection/subsite"))
            {
             //to get specific list type
               string listUrl = "/sites/sitecollection/subsite/Lists/Announcements";
               SPList list = web.GetList(listUrl);
               Console.WriteLine("List URL: {0}", list.RootFolder.ServerRelativeUrl);
            }
         }
