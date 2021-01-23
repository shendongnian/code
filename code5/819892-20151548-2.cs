    IEnumerable<Control> c = GetAllOrbs(this);
    foreach (Orb item in c.ToArray())
    {
        item.Dispose();
        //or if you prefer just to remove them use this:
        //item.Parent.Controls.Remove(item);
    }
.
    public IEnumerable<Control> GetAllOrbs(Control control)
    {
        var controls = control.Controls.Cast<Control>();
        return controls.SelectMany(ctrl => GetAllOrbs(ctrl, type)).Concat(controls).Where(c => c.GetType() == typeof(Orb));
    }
