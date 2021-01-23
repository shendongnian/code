        protected void LastProject()
             {
                 string lastProjUser = "SELECT name FROM Users WHERE id= (SELECT MAX(id) FROM Projects)";
                 string getconnstring = ConfigurationManager.ConnectionStrings["stad_conn"].ConnectionString;
                 SqlConnection conn = new SqlConnection(getconnstring);
                 using (SqlCommand lastProjUserName = new SqlCommand(lastProjUser, conn))
                 {
                     conn.Open();
                     lastProjUserName.CommandType = CommandType.Text;
                     SqlDataReader reader=lastProjUserName.ExecuteReader();
                     if(reader.Read())
                     {
                     string name = reader["name"].ToString();    
                     Label3.Text = name;
                     } 
                    conn.Close();
                 }
             }
        
         
    
    
       
    
           
