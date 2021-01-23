    private void ValidateTextBoxes()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    if (string.IsNullOrEmpty(c.Text))
                    {
                        MessageBox.Show(c.Name + " must be filled");
                        break;
                    }
                }
            }
        }
