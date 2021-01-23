     private void EnterBtn_Click(object sender, EventArgs e)
        {
            if (string.Equals(PsswdTxt.Text,"BuildStore"))
            {
                AdminPage m = new AdminPage();
                m.Show();
                this.Visible = false;
            }
            else
            {
              MessageBox.Show("Please Try again");
            }        
        }
