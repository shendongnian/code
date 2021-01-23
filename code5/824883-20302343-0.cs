    public int Ramiz_SavePack(IPacking pack, SqlConnection conn, SqlTransaction transaction)
    {
        var comm = (SqlCommand)connector.GetCommand("Ramiz_Pack_Save");
        comm.Connection = conn;
        comm.CommandType = CommandType.StoredProcedure;
        comm.Transaction = transaction;
        ....
    }
    .....
    try
    {    
        using (var conn = (SqlConnection)connector.GetConnection())
        {
            conn.Open();
            SqlTransaction transaction = conn.BeginTransaction();
            var pack = new Pack();
            for (int i = 1; i < lastRow; i++)
            {
               pack.Ramiz_SavePack(new Packing
               {
                   BrojKolete = Convert.ToString(brojKoleteRange.Offset[i, 0].Value2),
                   Bosanski = Convert.ToString(nazivArtiklaRange.Offset[i, 0].Value2),
                   Kom = Convert.ToDouble(komRange.Offset[i, 0].Value2),
                   Vrsta = Convert.ToString(vrstaRange.Offset[i, 0].Value2),
                   BrojKamiona = int.Parse(ddlBrojKamiona.SelectedItem.Value),
                   Datum = Convert.ToDateTime(txtDate.Text)
               }, conn, transaction);
            }
            pnlMessageSuccess.Visible = true;
         }
       }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        transaction.Rollback();
    }
