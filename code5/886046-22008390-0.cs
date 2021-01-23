    protected void Button1_Click(object sender, EventArgs e)
    {
       
       string connString = ConfigurationManager.ConnectionStrings["yourconnstringInWebConfig"].ConnectionString;
       SqlConnection conn = null;
       try
       {
              conn = new SqlConnection(connString);
              conn.Open();
    
              using(SqlCommand cmd = new SqlCommand())
              {
                     cmd.Conn = conn;
                     cmd.CommandType = CommandType.Text;
                     cmd.CommandText = "INSERT INTO Member_Details(column1,column2,column3,column4,column5,column6,column7,column8) Values (@var1,@var2,@var3,@var4,@var5,@var6,@var7,@var8)";
                     cmd.Parameters.AddWithValue("@var1", TextBox1.Text);
                     cmd.Parameters.AddWithValue("@var2", TextBox2.Text);
                     cmd.Parameters.AddWithValue("@var3", TextBox3.Text);
                     cmd.Parameters.AddWithValue("@var4", TextBox4.Text);
                     cmd.Parameters.AddWithValue("@var5", TextBox5.Text);
                     cmd.Parameters.AddWithValue("@var6", TextBox5.Text);
                     cmd.Parameters.AddWithValue("@var7", TextBox7.Text);
                     cmd.Parameters.AddWithValue("@var8", TextBox8.Text);
                     int rowsAffected = cmd.ExecuteNonQuery();
                     if(rowsAffected ==1)
                     {
                            //Success notification
                     }
                     else
                     {
                            //Error notification
                     }
              }
       }
       catch(Exception ex)
       {
              //log error 
              //display friendly error to user
       }
       finally
       {
              if(conn!=null)
              {
                     //cleanup connection i.e close 
              }
       }
    }
