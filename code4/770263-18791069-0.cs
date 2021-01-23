    else if (e.KeyCode == Keys.Return)
    {
        // Return
        if (!String.IsNullOrWhiteSpace(txtBox.Text))
            myButton.PerformClick();
        e.Handled = e.SuppressKeyPress = true;
    }
