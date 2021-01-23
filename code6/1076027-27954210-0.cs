    private List<Control> _tabControls = new List<Control>();
    public MyForm()
    {
        InitializeComponent();
        this.KeyPreview = true;
        TabControlsToList(this.Controls);
        _tabControls = _tabControls.OrderBy(x => x.TabIndex).ToList();
    }
    private void TabControlsToList(Control.ControlCollection controls)
    {
        foreach (Control control in controls)
        {
            if (control.TabStop == true)
                _tabControls.Add(control);
            if (control.HasChildren)
                TabControlsToList(control.Controls);
        }
    }
    protected override void OnKeyDown(KeyEventArgs args)
    {
        if ((args.Modifiers == Keys.Shift) && (args.KeyCode == Keys.Tab))
            interceptTabKey = !interceptTabKey;
        base.OnKeyDown(args);
    }
    private bool interceptTabKey = true;
    protected override bool ProcessTabKey(bool forward)
    {
        // We can intercept/process the [Keys.Tab] via this method.
        if (interceptTabKey)
        {
            if (forward)            // [Keys.Shift] was not used
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            else                    // [Keys.Shift] was used
            {
                int currentIndex = _tabControls.IndexOf(this.ActiveControl);
                var control = _tabControls[currentIndex == 0 ? _tabControls.Count - 1 : currentIndex - 1];
                control.Select();
            }
            // [return true;]  -- To indicate that a control is selected.
            return true;
        }
        // Do this normally when not intercepted
        return base.ProcessTabKey(forward);
    }
