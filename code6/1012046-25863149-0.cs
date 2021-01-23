    private void CreateControl(Control control)
    {
        var method = control.GetType().GetMethod("CreateControl", BindingFlags.Instance | BindingFlags.NonPublic);
        method.Invoke(control, new object[] { true });
    }
