    List<Point3D> list = new List<Point3D>();
    using (SqlDataReader reader = cmd.ExecuteReader())
    {
        while (reader.Read())
        {
            list.Add(new Point3D(reader.GetDouble(0), reader.GetDouble(1), reader.GetDouble(2)));
        }    
    }
