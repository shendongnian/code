    protected override void OnEnabledChanged(EventArgs e)
    {
        base.OnEnabledChanged(e);
        this.ForeColor = this.Enabled ? SystemColors.ControlText : this.BackColor;
    }
