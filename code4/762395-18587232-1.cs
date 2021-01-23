        private string getText(Control parent)
        {
            string output = string.Empty;
            foreach (Control aktControl in parent.Controls)
            {
                if (aktControl is TextBox)
                { output += (aktControl as TextBox).Text; }
            }
            return output;
        }
