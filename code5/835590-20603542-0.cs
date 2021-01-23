    private void RadioButtonChanged(object sender, EventArgs e)
    {
        ButtonA.Enabled = true;
    }
    private void HandleEvents()
    {
        this.RadioButton1.CheckedChanged += RadioButtonChanged;
        this.RadioButton2.CheckedChanged += RadioButtonChanged;
        this.RadioButton3.CheckedChanged += RadioButtonChanged;
    }
