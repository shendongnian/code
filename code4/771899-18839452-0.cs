    // Set using the visual Form Designer, generally
    lblName.TextChanged += lblName_TextChanged;
    // Later, the event handler
    private void lblName_TextChanged(object sender, EventArgs e)
    {
        lblYourName.Text = String.Format("Your name is {0}", lblName.Text);
    }
