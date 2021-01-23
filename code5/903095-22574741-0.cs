    try{
        string connStr = "Data Source=192.168.0.2;Initial Catalog=myDataBase/myInstance;
        Integrated Security=SSPI; User ID=myDomain\myUsername;Password=myPassword;";
        //new connection
        SqlConnection sqlConnection1 = new SqlConnection(connStr);
        sqlConnection1.Open();
        //new sqlCommand
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        string SKU = "";
        cmd.Parameters.Add(new SqlParameter("@barcode", Barcode));
        cmd.CommandText = "SELECT SKU, Quantity FROM Catalog.Barcodes WHERE Barcode = @barcode";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = sqlConnection1;
        //create reader
        reader = cmd.ExecuteReader();
        // Data is accessible through the DataReader object here.
        while (reader.Read())
        {
            SKU = reader.GetString(0);
        }
        sqlConnection1.Close();
     }catch (Exception ex){
        System.Diagnostics.Debug.WriteLine("Exception in sql code:" + ex.Message);
     }
