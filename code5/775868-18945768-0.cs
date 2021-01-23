    private void newGenreToolStripMenuItem_Click(object sender, EventArgs e)
    {
        //(cnSongs)Connection delacred and instantiated elsewhere
        cnSongs.Open();
        try {
            string input = Interaction.InputBox("Genre ", "New Genre", "Type genre here", -1, -1);
            Console.WriteLine("User input " + input);
            string InsertSql = "Insert Into tblGenres (Genre) Values (?)";
            OleDbCommand cmdInsert = new OleDbCommand(InsertSql, cnSongs);
            cmdInsert.Parameters.Add(new OleDbParameter("genre", input));
            int i = cmdInsert.ExecuteNonQuery();
            Console.WriteLine("Inseted " + i.toString() + " row(s)");
        } finally {
            cnSongs.Close();
        }
    }
