    ...
    myRadioButton.Checked += RunUpdateQuery_OnRadioButtonChecked;
    private void RunUpdateQuerry_OnRadioButtonChecked(object sender, EventArgs e)
    {  
      try
      {    
          using (SqlConnection connection = new SqlConnection(Connectionstring))
          {
              connection.Open();
              String updateQuerry = String.Format("UPDATE leavetable SET status = '{0}'  
                                       WHERE eid = '{1}  AND status = 'NULL'",   
                                       status, textBox1.Text);
              SqlCommand commad = new SqlCommand(updateQuerry, connection);
              if (command.ExecuteNonQuery() == 1)
              {
                  MessageBox.Show("status updated");
                  textBox1.Text = "";
                  textBox2.Text = "";
                  textBox3.Text = "";
                  textBox4.Text = "";
              }
           }
       }
       catch (Exception er)
       {
           MessageBox.Show(er.Message);
       }      
    }
