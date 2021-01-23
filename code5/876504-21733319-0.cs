    // wire all buttons to same event
    rb1.CheckedChanged += OnCheckChanged;
    rb2.CheckedChanged += OnCheckChanged;
    rb3.CheckedChanged += OnCheckChanged;
    private void OnCheckChanged(object sender, EventArgs e)
    {
        RadioButton rb = RadioButton(sender);
        if (rb.Checked)
        {
            if (rb.Name = "rb1")
                panel1.BringToFront();
            elseif (rb.Name = "rb2")
               panel2.BringToFront();
            else
               panel3.BringToFront();
        }
    }
