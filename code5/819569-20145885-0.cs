    public static void AddClass(this WebControl control, string newClass)
    {
        if(!string.IsNullOrEmpty(control.CssClass))
        {
             control.CssClass += " " + newClass;
        }
        else
        {
           control.CssClass = newClass;
        }
    }
