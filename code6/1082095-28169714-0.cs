    int nul = 0;
        string connect = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=|DataDirectory|Project.mdb";
        string SqlString = "Insert Into App (Naam, Site, Plaatje, Seconden) Values (@Naam,@Site,@Plaatje,@Seconden)";
        try
        {
            using (OleDbConnection conn = new OleDbConnection(connect))
            {
                using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Naam", Voernaamin.Text);
                    cmd.Parameters.AddWithValue("@Site", Voersitein.Text);
                    cmd.Parameters.AddWithValue("@Plaatje", Voerplaatjein.Text);
                    cmd.Parameters.AddWithValue("@Seconden", "0");
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Response.Redirect("Ingelogd2.aspx");
                }
            }
