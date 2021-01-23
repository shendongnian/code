       protected void TxtComments_TextChanged(object sender, EventArgs e)
        {
            if (TxtComments.Text.Trim().Equals(""))
            {
                LblErr.Text = "Please Enter a Comment!!!";
                LblErr.Visible = true;
                BtnSave.Enabled = false;
                BtnSave.BackColor = Color.LightGray;
                BtnSave.ForeColor = Color.Red;
            }    
            else
            {
                BtnSave.Enabled = true;
                BtnSave.BackColor = ColorTranslator.FromHtml("#666666");
                BtnSave.ForeColor = Color.White;
            }
        }     
