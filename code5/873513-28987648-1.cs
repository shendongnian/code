    flowLayoutPanel.ScrollControlIntoView(Control_To_Add); // Control_To_Add is the control we want to scroll to
    Button TempButton = new Button();
    TempButton.Width = _Panel.ClientRectangle.Width - 6; // Make the last control in the _Panel
    flowLayoutPanel.Controls.Add(TempButton); // We add this TempButton so we can scroll to the bottom of the _Panel.Controls
    flowLayoutPanel.ScrollControlIntoView(TempButton); // We scroll to TempButton at the bottom of the _Panel.Controls
    flowLayoutPanel.Controls.Remove(TempButton); // We remove TempButton
    b.Dispose(); // clean up
