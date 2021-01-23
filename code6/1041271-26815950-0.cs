           con.Open();
                                cmd.Connection = con;
                                cmd.CommandText = "select * from user where login=@login and pass=@psw";
                                cmd.Parameters.Add(new SqlParameter("@login", SqlDbType.VarChar, 255)).Value = txtpsedu.Text;
                                cmd.Parameters.Add(new SqlParameter("@psw", SqlDbType.VarChar, 255)).Value = txtlogin.Text;
    
       dr = cmd.ExecuteReader();
    
                        if (dr.Read())
                        {
                            
                       //// do  what  you  want  here  
    
                        }
    
                        else
                        {
    
                            Response.Write("User Name Incorrect!");
    
                        }
                        dr.Close();
                        con.Close();
