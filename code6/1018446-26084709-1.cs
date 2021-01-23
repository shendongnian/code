      public string username = string.Empty;
    
         private void LoginBT_Click(object sender, EventArgs e)
              {
                 username = txtUsername.Text;
                 Form3 form  = new Form3(username);
        
                 Form2 frm = new Form2(username);
                 frm.Show();
                 this.Hide
        }
