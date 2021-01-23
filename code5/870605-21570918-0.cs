    protected void ButtonSave_Click(object sender, EventArgs e)
        {
         if (MyCondition == true)
            {           
               modalPopUpConfirmation.Show();
            }
         else
            {            
                Label1.Text = "The condition was false, so no modal popup!";
            }
        }
