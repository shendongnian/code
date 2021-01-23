    protected override void OnEnabledChanged(EventArgs e)
    {
      base.OnEnabledChanged(e);
      if (this.Enabled)
        this.BackgroundImage = Properties.Resources.imgEnabled;
      else
        this.BackgroundImage = Properties.Resources.imgDisabled;
    }
