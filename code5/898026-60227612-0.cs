     protected void YourNameOfMethodForBothCheckBox(object sender, EventArgs e)
        {
            if (CheckBox_1.Checked == true)
            {
                Table_1.Visible = true;
                if (CheckBox_2.Checked == true)
                {
                    Table_2.Visible = true;
                }
                else { Table_2.Visible = false; }
            }
            else
            {
                Table_1.Visible = false;
                if (CheckBox_2.Checked == false)
                {
                    Table_2.Visible = false;
                }
                else
                {
                    Table_2.Visible = true;
                }
            }
            
        }
