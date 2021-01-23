    static void Main(string[] args)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\MUHAMMAD\Documents\samEE.mdf;Integrated Security=True;Connect Timeout=30";
        con.Open();
        SqlCommand cmd = new SqlCommand("Select * from Student", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            Console.WriteLine("Id is:"+dr[0]+" Name is:"+ dr[1]);
        }
        dr.Close();
        //con.Close();
        //SqlConnection con2 = new SqlConnection();
        //con2.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\MUHAMMAD\Documents\samEE.mdf;Integrated Security=True;Connect Timeout=30";
        cmd = new SqlCommand("Select Name from Student", con);
        //con2.Open();
        SqlDataReader dr2;
        dr2 = cmd.ExecuteReader();
        while (dr2.Read())
        {
            Console.WriteLine("Name is :"+ dr2[0]);
        }    
        dr2.Close();
        con.Close();
        Console.ReadKey();
    }
