    public IEnumerable<SelectListItem> GetCategoriesByAccountID(string AccountID)
        {
            List<SelectListItem> list = null;
    
            using (var context = new AMPEntities())
            {
                // Queries DB for list of categories by AccountID
                var query = (from ca in context.CustomAlerts
                            where ca.AccountID == AccountID
                            orderby ca.AlertCategory
                            select new SelectListItem { Text = ca.AlertCategory, Value = ca.AlertCategory }).Distinct();
                list = query.ToList();
    
                // Checks list to see if "INFORMATIONAL" already exists
                var item = (from l in list
                            where l.Value == "INFORMATIONAL"
                            select new SelectListItem { Text = l.Text, Value = l.Value }).FirstOrDefault();
    
                // If "INFORMATIONAL" is not present add it to list
                if (item == null)
                {
                    var newItem = new SelectListItem { Text = "INFORMATIONAL", Value = "INFORMATIONAL" };
                    list.Add(newItem);
                }
            }
    
            return list;
        }
