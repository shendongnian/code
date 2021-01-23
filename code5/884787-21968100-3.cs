    private void btnSaveCick(object sender,EventArgs e)
    {
      //save your data here
  
      //after saving your data call the CLearControls() function
      ClearControls(this);
    }
    void ClearControls(Control control)
    {
      foreach (Control c in control.Controls)
      {
        if (c is TextBox)
          ((TextBox)c).Clear();
        else if (c is RadioButton)
          ((RadioButton)c).Checked = false;
        else if (c is ComboBox)
          ((ComboBox)c).SelectedIndex = -1;
        if(c.HasChildren)
          ClearControls(c);
      }
    }
