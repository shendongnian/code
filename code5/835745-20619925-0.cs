    private void cboSelectEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSelectEmp.SelectedIndex >= 0)
            {
                SelectEmployeeInfo();
            }
            
        }
        private void SelectEmployeeInfo()
        {
            
            if (!string.IsNullOrWhiteSpace(cboSelectEmp.Text.Trim()))
            {
               string input = cboSelectEmp.Text.Trim();
                if (input.Split(' ').Length > 1)
                {
                    string formFirstNameValue = input.Split(' ')[0];
                    txtFirstName.Text = formFirstNameValue;
                    string formLastNameValue = input.Split(' ')[1].Replace(",", "");
                    txtLastName.Text = formLastNameValue;
                }
                
            }
               
        }
