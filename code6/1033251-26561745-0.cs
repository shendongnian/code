    public IQueryable<News> GetProducts()
    {
        var ctx = new SiteStiri.Models.NewsContext();
        var query = from n in ctx.News
                    where n.Description.Contains(SearchTxt)
                    select n;
        if ("DesDate".Equals(DropDownSelect.SelectedItem.Value))
        {
            query = query.OrderByDescending(u => u.ReleaseDate);
        }
        else if ("AsDate".Equals(DropDownSelect.SelectedItem.Value))
        {
            query = query.OrderBy(u => u.ReleaseDate);
        }
        else if ("AsAlp".Equals(DropDownSelect.SelectedItem.Value))
        {
            query = query.OrderBy(u => u.NewsTitle);
        }
        else if ("DesApl".Equals(DropDownSelect.SelectedItem.Value))
        {
            query = query.OrderByDescending(u => u.NewsTitle);
        }
        return query;
    }
