    private Dictionary<string, int> controlInstances = new Dictionary<string, int>();
    private string RenderControl(Control control)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter writer = new HtmlTextWriter(sw);
        int index = GetOrAddControlInstanceCount(control);
        control.ClientIDMode = ClientIDMode.Static;
        control.ID = control.GetType().Name + index;
        control.RenderControl(writer);
        return sb.ToString();
    }
    private int GetOrAddControlInstanceCount(Control control)
    {
        string key = control.GetType().Name;
        if (!controlInstances.ContainsKey(key))
        {
            controlInstances.Add(key, 0);
        }
        return controlInstances[key]++;
    }
