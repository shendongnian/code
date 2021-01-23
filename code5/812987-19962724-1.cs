           private bool IsValidateTextBoxSuccess(TextBox textBox, string messageString)
            {
                if (string.IsNullOrEmpty(textBox.Text.Trim()))
                {
                    MessageBox.Show(messageString, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
