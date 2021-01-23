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
