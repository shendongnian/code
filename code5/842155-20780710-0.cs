    private void button1_Click(object sender, EventArgs e)
    {
       foreach (Control c in this.Controls)
       {
          if (c is ComboBox)
          {
             ComboBox textBox = c as ComboBox;
             if (textBox.SelectedValue == null)
             {
                MessageBox.Show("please fill all fields");
                break;
             }
           }
           else
              recursiveComboboxValidator(c);
        }
    }
    
    void recursiveComboboxValidator(Control cntrl)
    {
        foreach (Control c in cntrl.Controls)
        {
           if (c is ComboBox)
           {
               ComboBox textBox = c as ComboBox;
               if (textBox.SelectedValue == null)
               {
                    MessageBox.Show("please fill all fields");
                    break;
               }
            }
            else
                recursiveComboboxValidator(c);
         }
    }
