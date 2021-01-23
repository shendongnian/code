      using (SPSite oSite = new SPSite(spsite))
      {
           using (SPWeb oWeb = oSite.OpenWeb())
           {
                var result = (from g in oWeb.Groups.OfType<SPGroup>()
                              where g.Name.Contains("_")
                              select g).ToList();
                foreach (SPGroup group in result)
                {
                    SPGroupCollection collGroups = oWeb.SiteGroups;
                    collGroups.Remove(group.Name);
                    Console.WriteLine("Removed " + group.Name);
                 }
                 Console.WriteLine("Process Complete!");
            }
