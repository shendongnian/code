    public IEnumerable<Control> setAllTextBoxs(Control control)
    {
        var controls = control.Controls.Cast<Control>();
        controls = controls.SelectMany(c => GetAll(c)).Concat(controls).Where(c => c is TextBox);
        controls.Where(c => c is TextBox).ToList().ForEach(t => (t as TextBox).BorderStyle = BorderStyle.FixedSingle);
        return controls;
    }
