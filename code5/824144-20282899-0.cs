    string constring = "datasource=localhost;port=3306;username=root;password=*****";
    string Query = "update database.aktiviteter set spejdere=@param1 where idak=@param2 ;";
    using(var connection= new MySqlConnection(constring))
    {
        var command= new MySqlCommand(Query, connection);
        command.Parameters.AddWithValue("@param1",this.spe_txt.Text);
        command.Parameters.AddWithValue("@param2",this.idak_txt2.Text);
        connection.Open();
        command.ExecuteNonQuery();
    }
