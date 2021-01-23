    pnl_ContactDetails.SuspendLayout();
    for(int i = 3; i < details.Count; i++)
    {
        TextPrompt txtbox = new TextPrompt(details[i]); //Textbox to be added
        MessageBox.Show(details[i].value);
        txtbox.Name = details[i].name; //Sets properties
        txtbox.Location = new Point(25, y);
        txtbox.Size = new System.Drawing.Size(345, 45);
        txtbox.TextValueChanged += new EventHandler(txtbox_TextChanged);
        /* txtbox.Show(); */ // Leave this call out in favor of:
        txtbox.Visible = true;
        this.pnl_ContactDetails.Controls.Add(txtbox);
        txtbox = (TextPrompt)this.pnl_ContactDetails.Controls[i - 3]; //Checks to make sure controls are on form.
        MessageBox.Show(txtbox.ContactDetails.name);
        y = y + 45;
    }
    pnl_ContactDetails.ResumeLayout();
