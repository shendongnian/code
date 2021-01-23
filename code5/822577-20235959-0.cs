    You have to first check that your combobox must not be empty before check condition
    you can do either
    protected void Page_Load(object sender, EventArgs e)
            {
                txtUsername.Focus();
                if (cmbThemes.SelectedItem!=null)
                {
                     if (cmbThemes.SelectedItem.Text=="Red")
                     {
                    //OtherOperations
                     }
                 }
            }
    Or
    
    protected void Page_Load(object sender, EventArgs e)
                {
                    txtUsername.Focus();
                    if (cmbThemes.SelectedIndex > -1)
                    {
                         if (cmbThemes.SelectedItem.Text=="Red")
                         {
                        //OtherOperations
                         }
                     }
                }
