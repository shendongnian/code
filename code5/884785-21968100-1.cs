    private void btnSaveCick(object sender,EventArgs e)
    {
      //save your data here
      ClearControls();
    }
    void ClearControls()
    {
        foreach (Control c in this.Controls)
         {
             if (c is TextBox)
        	 ((TextBox)c).Clear();
             else if(c is RadioButton)
        	 ((RadioButton)c).Checked=false;
             else if(c is ComboBox)
        	 ((ComboBox)c).SelectedIndex=-1;
         }
    }
