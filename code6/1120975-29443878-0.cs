    private bool validateDate(TextBox arg1)
            {
                DateTime dt;
                bool valid1 = DateTime.TryParseExact(arg1.Text.Trim(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt);
                if (!string.IsNullOrEmpty(arg1.Text.Trim()) )
                {
                    MessageBox.Show("Format Date is wrong! Currect format is(dd/MM/yyyy)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    arg1.Focus();
                    return false;
                }
                return true;
            }
