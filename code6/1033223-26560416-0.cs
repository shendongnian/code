     public Garage()
    {
        SqlConnection connection = new SqlConnection("Data   Source=fastapps04.qut.edu.au;Initial Catalog=*******;User ID=******;Password=******");
        connection.Open();
        SqlCommand command = new SqlCommand("SELECT Bay FROM Garage", connection);
        SqlDataReader reader = command.ExecuteReader();
        List<Garage> listBays =new List<Garage>();
        while (reader.Read())
        {
            temp = reader.GetInt32(reader.GetOrdinal("Bay"));
            listBays.Add(temp);
        }
        Garage[] Bays=listBays.ToArray();
        reader.Close();
        connection.Close();
    }
