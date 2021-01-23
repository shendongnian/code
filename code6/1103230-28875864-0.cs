    protected void Submit_Click(object sender, EventArgs e)
     {
         foreach (GridViewRow row in GridView1.Rows)
          {
            //Find the Radio button control
              RadioButtonList rb = (RadioButtonList)row.FindControl("Radio1");
              if (rb.SelectedItem != null)
              {
                  if (rb.SelectedItem.Text == "OK")
                   {
                      string id = row.Cells[2].Text;
                      string query = "Query";
    
                      SqlConnection con = new SqlConnection("Connection to DB");
                      SqlCommand cmd = new SqlCommand(query, con);
    
                      con.Open();
                      added = cmd.ExecuteNonQuery();
    
                      con.Close();
                  }
              }
          }
       }
