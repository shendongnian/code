    if (e.KeyCode < Keys.D1 || e.KeyCode > Keys.D6 || e.Shift || e.Alt)
            {
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = false;
            }
