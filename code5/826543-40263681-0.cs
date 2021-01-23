    use this helper class : 
    
    namespace Projectname.UI.HtmlHelpers
    {
        //[DebuggerNonUserCodeAttribute()]
        public static class SessionHelper
        {
            public static T Get<T>(string index)
            {
                //this try-catch is done to avoid the issue where the report session is timing out and breaking the entire session on a refresh of the report            
                
                
                if (HttpContext.Current.Session == null)
                {
                    var i = HttpContext.Current.Session.Count - 1;
    
                    while (i >= 0)
                    {
                        try
                        {
                            var obj = HttpContext.Current.Session[i];
                            if (obj != null && obj.GetType().ToString() == "Microsoft.Reporting.WebForms.ReportHierarchy")
                                HttpContext.Current.Session.RemoveAt(i);
                        }
                        catch (Exception)
                        {
                            HttpContext.Current.Session.RemoveAt(i);
                        }
    
                        i--;
                    }
                    if (!HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.Equals("~/Home/Default"))
                    {
                        HttpContext.Current.Response.Redirect("~/Home/Default");
                    }
                    throw new System.ComponentModel.DataAnnotations.ValidationException(string.Format("You session has expired or you are currently logged out.", index));
                }
    
                try
                {
                    if (HttpContext.Current.Session.Keys.Count > 0 && !HttpContext.Current.Session.Keys.Equals(index))
                    {
    
                        return (T)HttpContext.Current.Session[index];
                    }
                    else
                    {
                        var i = HttpContext.Current.Session.Count - 1;
    
                        while (i >= 0)
                        {
                            try
                            {
                                var obj = HttpContext.Current.Session[i];
                                if (obj != null && obj.GetType().ToString() == "Microsoft.Reporting.WebForms.ReportHierarchy")
                                    HttpContext.Current.Session.RemoveAt(i);
                            }
                            catch (Exception)
                            {
                                HttpContext.Current.Session.RemoveAt(i);
                            }
    
                            i--;
                        }
                        if (!HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.Equals("~/Home/Default"))
                        {
                            HttpContext.Current.Response.Redirect("~/Home/Default");
                        }
                        throw new System.ComponentModel.DataAnnotations.ValidationException(string.Format("You session does not contain {0} or has expired or you are currently logged out.", index));
                    }
                }
                catch (Exception e)
                {
                    var i = HttpContext.Current.Session.Count - 1;
    
                    while (i >= 0)
                    {
                        try
                        {
                            var obj = HttpContext.Current.Session[i];
                            if (obj != null && obj.GetType().ToString() == "Microsoft.Reporting.WebForms.ReportHierarchy")
                                HttpContext.Current.Session.RemoveAt(i);
                        }
                        catch (Exception)
                        {
                            HttpContext.Current.Session.RemoveAt(i);
                        }
    
                        i--;
                    }
                    if (!HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.Equals("~/Home/Default"))
                    {
                        HttpContext.Current.Response.Redirect("~/Home/Default");
                    }
                    return default(T);
                }
            }
    
            public static void Set<T>(string index, T value)
            {
                HttpContext.Current.Session[index] = (T)value;
            }
        }
    }
    
    and in your controller you set everything e g : login controller 
    
    Session Helper.Set<string>("Username", Login User.User Name);
     Session Helper.Set<int?>("Tenant Id", Login User.Tenant Id);
                        SessionHelper.Set<User Type>("User Type");
                        SessionHelper.Set<string>("", Login User To String());
                        SessionHelper.Set<int>("Login User Id", Login User.Login UserId);
                        SessionHelper.Set<string>("Login User", Login User.To String());
                        SessionHelper.Set<string>("Tenant", Tenant);
                        SessionHelper.Set<string>("First name", Login User.First Name);
                        SessionHelper.Set<string>("Surname", Login User.Surname);
                        SessionHelper.Set<string>("Vendor ", Vendor );
                        SessionHelper.Set<string>("Wholesaler ", Wholesaler );
                        SessionHelper.Set<int?>("Vendor Id", Login User );
                        SessionHelper.Set<int?>("Wholesaler Id", Login User Wholesaler Id);
    
    and you just call it anywhere you want :
    
    var CreatedBy = SessionHelper.Get<int>("LoginUserId"),
    
    it is a simple get to the the entity or set to assign it 
    
    
     
