    [WebMethod]
    public static string GetCustomers(int pageIndex)
    {
        Page pageHolder = new Page();
        UserControl viewControl = (UserControl)pageHolder.LoadControl("_path_to_customers_usercontrol");
    
        pageHolder.Controls.Add(viewControl);
    
        StringWriter output = new StringWriter();
        HttpContext.Current.Server.Execute(pageHolder, output, false);
    
        return output.ToString();
    }
