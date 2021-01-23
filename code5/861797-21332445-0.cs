    protected void Page_Init(object sender, EventArgs e)
    {
        for (int i = 0; i < 4; ++i)
        {
            RadioButton rb = new RadioButton() { AutoPostBack = true, Text = "Initial text" };
            rb.CheckedChanged += RadioButton_CheckedChanged;
            Form.Controls.Add(rb); // Or add to a panel if you prefer
        }
    }
