    public static string Infosession 
    { 
        get 
        {
            object value = HttpContext.Current.Session["infosession"];
            return value == null ? "" : (string)value;
        }
        set 
        {
            HttpContext.Current.Session["infosession"] = value;
        }
    }
