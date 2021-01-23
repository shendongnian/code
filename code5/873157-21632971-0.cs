    List<SelectListItem> serverItems = new List<SelectListItem>();
                serverItems.Add(new SelectListItem { Text = "P", Value = "P" });
                serverItems.Add(new SelectListItem { Text = "A1", Value = "A1" });
                serverItems.Add(new SelectListItem { Text = "A2", Value = "A2" });
                serverItems.Add(new SelectListItem { Text = "T1", Value = "T1" });
                serverItems.Add(new SelectListItem { Text = "T2", Value = "T2" });
    
                string selectedValue = System.Configuration.ConfigurationManager.AppSettings["server:serverName"].ToString();
    
                SelectListItem item = serverItems.Where(t => t.Value == selectedValue).SingleOrDefault();
    
                if (item != null)
                {
                    item.Selected = true;
                }
