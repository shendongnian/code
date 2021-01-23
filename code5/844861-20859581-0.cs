    public void objChecked(Control x, bool enabled)
    {
        PropertyInfo pi =  x.GetType().GetProperty("Checked");
        if (pi != null && pi.PropertyType == System.Type.GetType("System.Boolean"))
            pi.SetValue(x, enabled);
    }
