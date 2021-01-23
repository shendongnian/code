    button2.Enabled = true;
    foreach (var testBox in this.Controls.OfType<TextBox>())
    {
        if (string.IsNullOrEmpty(textBox.Text))
        {
            button2.Enabled = false;
            break;
        }
    }
