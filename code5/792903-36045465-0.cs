    [WebMethod]
    public static void RemoveReportFromSession()
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
    }
