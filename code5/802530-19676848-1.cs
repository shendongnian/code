    private IEnumerable<T> GetControls<T>(Control.ControlCollection ctrls)
    {
        foreach (object ctrl in ctrls)
        {
            foreach (var item in GetControls<T>(((Control)ctrl).Controls))
            {
                yield return item;    
            } 
            if (ctrl is T)
               yield return (T)ctrl;
        }
    }
    foreach(var txtbox in  GetControls<TextBox>(form.Controls)
    {
        txtbox.ReadOnly = false;
    }
