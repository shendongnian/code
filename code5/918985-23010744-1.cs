     protected void RadioButtonIsActive_CheckedChanged(object sender, EventArgs e)
            {
                foreach (GridViewRow row in gvwQueues.Rows)
                {
                    RadioButton yesRadioButton = (RadioButton)row.FindControl("yesRadioButton");
                    if (yesRadioButton.Checked)
                    {
                        //Make Items Active
                    }
    
                    else
                    {
                        //Make Items Inactive
                    }
                }
            }
