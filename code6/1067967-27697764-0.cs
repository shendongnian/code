    foreach (Control ctrl in this.Controls)
    {
        if (ctrl as TextBox != null)
        {
            ctrl.Text = string.Empty;
        }
        if (ctrl as ComboBox != null)
        {
            ((ComboBox)ctrl).SelectedIndex = -1;
        }
    }
