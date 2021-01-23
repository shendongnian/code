    public List<SelectListItem> GetCategories()
    {
        var db = new MainDatabaseEntities();
        List<SelectListItem> list = new List<SelectListItem>();
        // Add empty item if needed
        SelectListItem commonItem = new SelectListItem();
        commonItem.Text = "--- Select ---";
        commonItem.Value = "-1";
        commonItem.Selected = true;
        list.Add(commonItem);
        // Add items from Database
        foreach (ForumCategory fc in db.ForumCategory)
        {
            SelectListItem i = new SelectListItem();
            i.Text = fc.CATEGORY;
            i.Value = fc.CA_ID.ToString();
            list.Add(i);
        }
        return list;
    }
