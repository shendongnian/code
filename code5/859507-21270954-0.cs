        string cnString = null;
        cnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\POS.mdb";
        conn = new OleDbConnection(cnString);
        try
        {
            conn.Open();
            // Now that the connection is open, it can be used below
            this.ProductsTableAdapter.Fill(this.ProductDataSet.Products);
            this.SalesTableAdapter.Fill(this.SalesDataSet.Sales);
        }
        catch (OleDbException ex)
        {
            MessageBox.Show(ex.Message, "Error..", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
