    private void textbox1_Enter(object sender, EventArgs e)
            {
                if (!string.IsNullOrEmpty(textbox1.Text))
                {
                    OldValue = textbox1.Text.Trim();
                }
                
            }
