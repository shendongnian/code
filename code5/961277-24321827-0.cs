    public static Class1 Current
    {
        get
        {
            if (HttpContext.Current != null) /* ASP.NET / ASMX / ASHX */
            {
                if (HttpContext.Current.Session["Class1"] == null)
                    HttpContext.Current.Session["Class1"] = new Class1();
                return (Class1)HttpContext.Current.Session["Class1"];
            }
            else if (OperationContext.Current != null) /* WCF */
            {
                if (WcfInstanceContext.Current["Class1"] == null)
                    WcfInstanceContext.Current["Class1"] = new Class1();
                return (Class1)WcfInstanceContext.Current["Class1"];
            }
            else /* WPF / WF / Single instance applications */
            {
                if (Class1.current == null)
                    Class1.current = new Class1();
                return Class1.current;
            }
        }
    }
