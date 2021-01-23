    using (OleDbCommand cmd = new OleDbCommand(), cmd2 = new OleDbCommand())
    {
        string cartID = "Cart1";               //
        int produitID = 1;                     // test data
        string attributs = "je ne sais quoi";  //
        int numLivre = 1;                      //
        cmd.Connection = con;  // existing OleDbConnection, already .Open()
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.CommandText =
                "SELECT * FROM ShoppingCart " +
                "WHERE cartID=? AND produitID=?";
        cmd.Parameters.Add("?", OleDbType.VarWChar, 255).Value = cartID;
        cmd.Parameters.Add("?",OleDbType.Integer).Value = produitID;
        var da = new OleDbDataAdapter(cmd);
        var cb = new OleDbCommandBuilder(da);
        cb.QuotePrefix = "["; cb.QuoteSuffix = "]";
        var dt = new System.Data.DataTable("ShoppingCart");
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            int n = Convert.ToInt32(dt.Rows[0]["Quantite"]);
            dt.Rows[0]["Quantite"] = ++n;
        }
        else
        {
            cmd2.Connection = con;
            cmd2.CommandText =
                    "SELECT COUNT(*) AS n FROM livres WHERE NumLivre=?";
            cmd2.Parameters.AddWithValue("?", numLivre);
            int n = Convert.ToInt32(cmd2.ExecuteScalar());
            if (n > 0)
            {
                System.Data.DataRow dr = dt.NewRow();
                dr["CartID"] = cartID;
                dr["ProduitID"] = produitID;
                dr["Attributs"] = attributs;
                dr["Quantite"] = 1;
                dr["DateAjoute"] = DateTime.Today;
                dt.Rows.Add(dr);
            }
        }
        da.Update(dt);
    }
