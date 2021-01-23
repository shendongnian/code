    using System.Web;
    [...]
    public void SaveChanges()
    {
        var username = HttpContext.Current.User.Identity.Name;
    }
