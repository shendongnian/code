    [WebMethod]
    public static Student[] GetStudents()
    {        
        String connectionString = ConfigurationManager.ConnectionStrings["str"].ConnectionString;
        using(SqlConnection con = new SqlConnection(connectionString))
        using(SqlCommand cmd = con.CreateCommand())
        {
            cmd.CommandText = "SELECT * FROM [student]";
            con.Open();
            
            List<Student> ret = new List<Student>();
            
            using(SqlDataReader rdr = cmd.ExecuteReader())
            {
                while(rdr.Read())
                {
                    ret.Add( new Student() {
                        Name = rdr.GetString("Name"),
                        Address = rdr.GetString("Address"),
                        Sex = rdr.GetString("Sex"),
                        Email = rdr.GetString("Email")
                    } );
                }//while
            }//using
            
            return ret.ToArray();
        }//using 
    }//GetStudents
