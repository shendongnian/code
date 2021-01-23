    private void MacAdressTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        // Disable formatting code when backspacing
        if (e.KeyCode == Keys.Back) { updatingTextWithCode = true; }
    }
