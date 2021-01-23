    public IQueryable<Screening> GetProducts()
    {
        var _db = new ProductContext();
        IQueryable<Screening> query = _db.Screenings;
        if (!String.IsNullOrEmpty(Request.QueryString["id"]))
        {
            query = query.Where(p => p.ScreeningID == Request.QueryString["id"]);
        }
        else if (Page.RouteData.Values["internalId"] != null && !String.IsNullOrEmpty(Page.RouteData.Values["internalId"] as string))
        {
            query = query.Where(p => p.InternalId == Page.RouteData.Values["internalId"].ToString());
        }
        return query;
    }
