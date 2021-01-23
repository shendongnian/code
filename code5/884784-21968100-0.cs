    private void btnCLick(object sender,EventArgs e)
    {
              foreach (Control c in this.Controls)
                {
                    if (c is TextBox)
                        ((TextBox)c).Clear();
                    else if(c is CheckBox)
                        ((RadioButton)c).Checked=false;
                    else if(c is ComboBox)
                        ((ComboBox)c).SelectedIndex=0;
                }
           
    }
