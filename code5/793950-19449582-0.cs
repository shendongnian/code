    public string getMenuItems(int parentId)
    {
        using (dynamicMenuEntities context = new dynamicMenuEntities())
        {
            string tags = new string();
            tags += "<ul>";
    
            var menuObj = from r in context.Menus
                          where r.ParentId == parentId
                          select new { r.MenuName, r.URL, r.Id };
    
    
            foreach (var obj in menuObj)
            {
                tags += "<li>";
                int childCount = context.Menus.Count(ch => ch.ParentId == obj.Id);
                if (childCount > 0)
                {
                    tags += obj.MenuName;
                    tags += getMenuItems(obj.Id);
                }
                else
                {
                    tags += "<a target=\"_blank\" href='" + Page.ResolveUrl(obj.URL) + "'>" + obj.MenuName + "</a>";
                }
               
                tags += "</li>"
            }
            tags += "</ul>";
            return tags;
        }
