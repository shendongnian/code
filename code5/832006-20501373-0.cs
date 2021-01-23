    static void Main(string[] args)
    {
    SqlConnection con = new SqlConnection();
    con.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\USERS\MUHAMMAD\DOCUMENTS\SAMEE.MDF;Integrated Security=True;Connect Timeout=30;User Instance=True";
    SqlCommand cmd =  new SqlCommand("Select * from [Table]",con );
    con.Open();
    SqlDataReader dr;
    dr = cmd.ExecuteReader();
    while(dr.Read())
    {
    Console.WriteLine("{0}",dr[0].ToString());
    }
    Console.ReadKey(); 
    }
