    void bigButton_MouseEnter(object sender, EventArgs e)
    {
        // Hide the button
        bigButton.Visible = false;
        // Listen for position changes.
        // We have to do that on the form, because the
        // button is hidden and won't get notified
        MouseMove += bigButton_MouseMove;
    }
