    string sql = "SELECT Aname FROM Pet WHERE Species = @Species;";
    using(var myConnection = new System.Data.OleDb.OleDbConnection("Connection-String"))
    using (var myCommand = new System.Data.OleDb.OleDbCommand(sql, myConnection))
    {
        myCommand.Parameters.AddWithValue("@Species", DropSpecies1.SelectedItem.ToString());
        try {
            myConnection.Open();
            List<string> animals = new List<string>();
            using (var rd = myCommand.ExecuteReader())
            {
                while (rd.Read())
                    animals.Add(rd.GetString(0));
            }
            TextBox2.Lines = animals.ToArray();  
            // or via String.Join:
            TextBox2.Text = String.Join(Environment.NewLine, animals);              
        } catch (Exception ex)
        {
            Label1.Text = "Exception in DBHandler" + ex.ToString();
        }
    }
