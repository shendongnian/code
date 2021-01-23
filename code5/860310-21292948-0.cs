    private void AuthSelect_SelectedIndexChanged(object sender, EventArgs e)
            {
                //listen if combobox selection is changed
                if ((AuthSelect.SelectedIndex == 0) || (AuthSelect.SelectedIndex == -1))
                {
                    userName.ReadOnly = true;
                    password.ReadOnly = true;
                }
                else
                {
                    userName.ReadOnly = false;
                    password.ReadOnly = false;
                }      
            }
