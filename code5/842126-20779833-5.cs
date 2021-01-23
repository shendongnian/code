    protected void BtnSave_Click(object sender, EventArgs e)
    {
       if (TxtComments.Text.Trim().Equals(""))
        {
            LblErr.Text = "Please Enter a Comment!!!";
            LblErr.Visible = true;
            BtnSave.Enabled = false;
            BtnSave.BackColor = Color.LightGray;
            BtnSave.ForeColor = Color.Red;
        }    
       else if (DrpForYear.SelectedItem.Text == "Please Select" || DrpForMonth.SelectedItem.Text == "Please Select" || RadView.SelectedItem.Text == "")
        {
            LblErr.Text = "Invalid Selection!!!";
            LblErr.Visible = true;
            BtnSave.Enabled = false;
            BtnSave.BackColor = Color.Gray;
            BtnSave.ForeColor = Color.Red;
        }
        else
        {
              /*your code*/
        }
      }
