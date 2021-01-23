        int artikelnummer = 1;
        //Connect
        string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\jeroen\Documents\Visual Studio 2010\Projects\producten\producten\App_Data\Bimsports.accdb;Persist Security Info=True";
        OleDbConnection conn = new OleDbConnection(connectionstring);
        //Execute
        string sql = "SELECT Merk, Maat, Omschrijving, Kleur, Prijs, BTW, Categorie.Categorie FROM Artikel INNER JOIN Categorie ON Artikel.Categorie = Categorie.Categorienummer WHERE Artikelnummer =?";
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        cmd.Parameters.AddWithValue("Artikelnummer", artikelnummer);
        //Read
        try
        {
            conn.Open();
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lbl_merk.Text = reader["Merk"].ToString();
                lbl_maat.Text = reader["Maat"].ToString();
                lbl_omschrijving.Text = reader["Omschrijving"].ToString();
                lbl_kleur.Text = reader["Kleur"].ToString();
                lbl_prijs.Text = reader["Prijs"].ToString();
                lbl_btw.Text = reader["BTW"].ToString();
                lbl_categorie.Text = reader["Categorie"].ToString();
            }
            string sUrl = string.Format("~/afbeelding.ashx?artikelnummer={0}", artikelnummer);
            img_nikeshirt.ImageUrl = sUrl;
        }
        catch
        {
        }
        finally
        {
            conn.Close();
        }
    }
