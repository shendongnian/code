        string constring = "Data Source=.;Initial Catalog=db.MDF;Integrated Security=True";
        string Query = "select * from RePriorities where Priority=@priority";
        using(SqlConnection conDataBase = new SqlConnection(constring))
        using(SqlCommand cmdDataBase = new SqlCommand(Query, conDataBase))
        {
            conDataBase.Open();
            cmdDataBase.Parameters.AddWithValue("@priority", cbType.SelectedItem.ToString();
     
            ......
            // the rest of your code
        }
