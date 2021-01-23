     int index=0;
     foreach (GridViewRow row in GridView1.Rows)
        {
           
            if (row.RowType == DataControlRowType.DataRow)
            {
                      Label ID = GridView1.Rows[index].FindControl("lblID") as Label;
                      Label NAME = GridView1.Rows[index].FindControl("lblQue") as Label;
                      TextBox LOC = GridView1.Rows[index].FindControl("txtPM") as TextBox;
                    SqlConnection con = new SqlConnection(strConnString);
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into myTable(ID, NAME, LOC ) values(@ID, @NAME,  @LOC) " +
                        // "where ID=@ID;" + 
                     "SELECT ID, NAME, LOC FROM MYTABLE";
                    cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID.Text;
                    cmd.Parameters.Add("@NAME", SqlDbType.VarChar).Value = NAME.Text;
                    cmd.Parameters.Add("@LOC", SqlDbType.VarChar).Value = LOC.Text;
                    GridView1.EditIndex = -1;
                    GridView1.DataSource = GetData(cmd);
                    GridView1.DataBind();
            }
             index++;
        }
