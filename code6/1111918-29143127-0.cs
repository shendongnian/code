    private DataTable GetData()
        {
            SqlConnection con = new SqlConnection("Data Source=NB465\\SQLEXPRESS;Initial Catalog=Movie;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT id, Nome, Cognome FROM Anagrafica");
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
