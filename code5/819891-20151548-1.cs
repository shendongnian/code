    IEnumerable<Control> c = GetAll(this);
    foreach (Orb item in c.ToArray())
    {
        item.Dispose();
    }
.
    public IEnumerable<Control> GetAllOrbs(Control control)
    {
        var controls = control.Controls.Cast<Control>();
        return controls.SelectMany(ctrl => GetAllOrbs(ctrl, type)).Concat(controls).Where(c => c.GetType() == typeof(Orb));
    }
