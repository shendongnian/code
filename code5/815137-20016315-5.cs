    private void MenuItemNew()
            {
                if (textBox.Text.ToString().Trim().Equals(""))
                {
                    textBox.Text = String.Empty;
                }
                else
                {
    DialogResult result3 = MessageBox.Show("Do you want to save changes to Untitled?","The Question",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
    
            if (result3 == DialogResult.Yes)
            {
                //statements if Result = Yes
            }
            else if (result3 == DialogResult.No)
            {
                //statements if Result = NO
            }
    
            }//end of else block
         }//end of function
