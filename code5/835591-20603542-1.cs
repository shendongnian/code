    private void RadioButtonChanged(object sender, EventArgs e)
    {
        ButtonA.Enabled = true;
    }
    private void HandleEvents()
    {
        foreach(var rb in new[] {RadioButton1, RadioButton2, RadioButton3})
            rb.CheckedChanged += RadioButtonChanged;
    }
