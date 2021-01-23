    bool stat
            string connectionString = "Data Source=|DataDirectory|'\'CarsDB.sdf;Initial  Catalog=TestDB;Integrated Security=true;";
    try
    {
         conn = new SqlCeConnection(connectionString );
         conn.Open();
            textBox2.Text = "true";  
       /*  SqlCeCommand cmd = conn.CreateCommand();
         cmd.CommandText = "INSERT INTO Customers ([Customer ID], [Company Name]) Values('NWIND', 'Northwind Traders')";
    cmd.ExecuteNonQuery();*/
    }
     catch (System.Exception)
        {
            stat = false;
            textBox2.Text = "false";
        }
