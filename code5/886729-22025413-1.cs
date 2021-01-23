     foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    Label ID = row.FindControl("lbl_ID") as Label;                
                    TextBox myUID = row.FindControl("txt_UID") as TextBox;
                    string Full_Name = Request.Form[row.FindControl("txt_UID").UniqueID];
    
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConn"].ConnectionString);
                    SqlCommand cmd = new SqlCommand();
    
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"if not exists(select ID from myTable where ID = @ID)
                                       insert into myTable(ID, Full_Name) values(@ID, @Full_Name)
                                        else update myTable set Full_Name =@Full_Name where ID =@ID";
                    foreach(string currentName in Full_Name.Split(','))
                    {
                        if (currentName!="")
                        {
                            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = ID.Text;
                            cmd.Parameters.Add("@Full_Name", SqlDbType.VarChar).Value = currentName;
    
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            cmd.Parameters.Clear();
                        }
                    }
    
                }
    }
