    // Return non-empty name specified in a [Display] attribute for the given field, if any; field's name otherwise
    private static string GetDisplayName(FieldInfo field)
    {
        DisplayAttribute display = field.GetCustomAttribute<DisplayAttribute>(inherit: false);
        if (display != null)
        {
            string name = display.GetName();
            if (!String.IsNullOrEmpty(name))
            {
                return name;
            }
        }
        
        return field.Name;
    }
