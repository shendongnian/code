        var connexion = new SqlConnection(@"Data Source=..."); 
        var command = connexion.CreateCommand();
        var requete = "INSERT INTO commande VALUES(@idpr,@date)";
        // I've assumed the types - double check
        var paramidprod = new SqlParameter("@idpr", SqlDbType.VarChar);
        var paramdate = new SqlParameter("@date", SqlDbType.DateTime);
        command.Parameters.Add(paramidprod);
        command.Parameters.Add(paramdate);
        command.CommandText = requete;
        connexion.Open(); 
        foreach (string line in lines)
        {
           if (line.Contains('*')) break;
           String[] l = line.Split(';');
           paramidprod.Value = line.Substring(0,2);
           paramdate.Value = l[1];
           command.ExecuteNonQuery();
        }
        connexion.Close();
        connexion.Dispose();
