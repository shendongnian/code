    var dynamicControls = vs["DynamicControls"] as List<Tuple<Type, string>>;
    if (dynamicControls != null)
    {
        foreach (var tp in dynamicControls)
        {
            Control c = Activator.CreateInstance(tp.Item1) as Control;
            c.ID = tp.Item2;
            this.Controls.Add(c);
        }
    }
