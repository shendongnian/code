    public static string GetImagesPath()
    {
        var CustomerNumber = HttpContext.Current.User.Identity.GetCustomerNumber().Result;
        if (!string.IsNullOrEmpty(CustomerNumber))
        {
            return HttpContext.Current.Server.MapPath(string.Format("~/Media/{0}/UserImages/", CustomerNumber));
        }
        return string.Empty;
    }
