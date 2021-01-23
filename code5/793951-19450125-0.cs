     public string getMenuItems(int parentId)
    {
        using (dynamicMenuEntities context = new dynamicMenuEntities())
        {
            var menuObj = from r in context.Menus
                          where r.ParentId == parentId
                          select new { r.MenuName, r.URL, r.Id };
            foreach (var obj in menuObj)
            {
                sbMenu.Append("<li><a target=\"_blank\" href='" + Page.ResolveUrl(obj.URL) + "'>" + obj.MenuName + "</a>");
                childCount = context.Menus.Count(r => r.ParentId == obj.Id);
                if (childCount > 0)
                {
                    sbMenu.Append("<ul>");
                    getMenuItems(obj.Id);
                }
                else
                {
                    sbMenu.Append("</ul>");
                }
            }
        }
        return sbMenu.ToString();
    }
