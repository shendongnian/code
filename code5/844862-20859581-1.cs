    delegate void MyDelegate(object control, object enabled);
    public void objChecked(Control x, bool enabled)
    {
        System.Reflection.PropertyInfo pi = x.GetType().GetProperty("Checked");
        if (pi != null && pi.PropertyType == System.Type.GetType("System.Boolean"))
        {
            if (x.InvokeRequired)
                BeginInvoke(new MyDelegate(pi.SetValue), new object[] { x, enabled });
            else
                pi.SetValue(x, enabled);
        }
    }
