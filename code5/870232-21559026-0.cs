    public static List<Control> GetAllControls(List<Control> controls, Type t, Control parent /* can be Page */)
    {
    foreach (Control c in parent.Controls)
    {
    if (c.GetType()== t)
    controls.Add(c);
    if (c.HasControls())
    controls = GetAllControls(controls, t, c);
    }
    return controls;
    }
