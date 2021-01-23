     static void Main(string[] args)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\MUHAMMAD\Documents\samEE.mdf;Integrated Security=True;Connect Timeout=30";
                SqlCommand cmd = new SqlCommand("Select Id,Name from Student", con);
                con.Open();
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine("Id is:"+dr[0]+" Name is:"+ dr[1]);
    				
                }
                con.Close();
                con.Dispose();  
                Console.ReadKey();
            }
