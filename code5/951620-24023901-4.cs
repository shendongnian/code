    public IEnumerable<Control> GetAll(Control control)
    {
       var controls = control.Controls.Cast<Control>();
    
       return controls.SelectMany(ctrl => GetAll(ctrl))
                      .Concat(controls);
    }
