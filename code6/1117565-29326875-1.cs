        private void button1_Click(object sender, EventArgs e)
    {
        SetReadonlyControls(groupBox1.Controls);
    }
    private void SetReadonlyControls(Control.ControlCollection controlCollection)
    {
        if (controlCollection == null)
        {
            return;
        }
        foreach (TextBoxBase c in controlCollection.OfType<TextBoxBase>())
        {
            c.ReadOnly = true;
        }
    }
