    private void Timer_Tick(object sender, EventArgs e)
    {
        var textbox = textboxes[nextTextBox];
        nextTextBox++; //you can put this inside the if if that's what you want
        if (!string.IsNullOrEmpty(textbox.Text))
        {
            SendKeys.Send(textbox.Text);
            SendKeys.Send("{ENTER}");
        }
    }
