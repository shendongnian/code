    private void txtNewNotes_KeyDown(object sender, KeyPressEventArgs e)
            {
                if (txtNewNotes.Text.Length == 0) return;
    
                if (e.KeyChar == '\r')
                {
                    e.Handled = false;
                    return;
                }
    
                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                    return;
                }
    
                int index = txtNewNotes.GetLineFromCharIndex(txtNewNotes.SelectionStart);
                string temp = txtNewNotes.Lines[index];
                if (temp.Length < 45) // character limit
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
