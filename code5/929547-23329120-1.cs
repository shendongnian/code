    List<Cube1> cubelist = new List<Cube1>();
    while (dr.Read())
    {
        // Create a new Cube1 instance
        var cube = new Cube1();
        // Set its properties
        cube.itemname = dr.GetValue(0).ToString();
        cube.city = dr.GetValue(1).ToString();
        cube.month = dr.GetValue(2).ToString();
        cube.totalsales = (int)dr.GetValue(3);
        // Add it to the list
        cubelist.Add(cube);
        MessageBox.Show(cube.totalsales.ToString());
    }
