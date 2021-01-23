    private bool SupportsTransparentBackColor(ToolStripItem item)
    {
        var host = item as ToolStripControlHost;
        if (host != null)
        {
            return SupportsTransparentBackColor(host.Control);
        }
        return true;
    }
    private bool SupportsTransparentBackColor(Control control)
    {
        MethodInfo getstyle = typeof(Control).GetMethod("GetStyle", BindingFlags.Instance | BindingFlags.NonPublic);
        return (bool)getstyle.Invoke(control, new object[] { ControlStyles.SupportsTransparentBackColor });
    }
    bool textboxResult = SupportsTransparentBackColor(textBox1);//false
    bool labelResult = SupportsTransparentBackColor(label1);//true
