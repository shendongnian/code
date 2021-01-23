    public static async Task<string> GetImagesPath()
    {
        var context = HttpContext.Current;
        return await Task.Factory.StartNew<string>(() =>
        {
            var CustomerNumber = context.User.Identity.GetCustomerNumber().Result;
            if (!string.IsNullOrEmpty(CustomerNumber))
            {
                return context.Server.MapPath(string.Format("~/Media/{0}/UserImages/", CustomerNumber));
            }
            return string.Empty;
        });
    }
