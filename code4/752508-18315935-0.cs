    Color pix;
    var myList = new List<myPixel>();
    for (y = 0; y < grid_y; y++)
    {
        for (x = 0; x < grid_x; x++)
        {
            Console.WriteLine("({0},{1})",x,y);
            pix = image.GetPixel(x, y);
            myPixels.Add(new myPixel() { Pixel = pix, X = x, Y = y});
        }
    }
    var dataTable = //convert your object to a datatable
    dbConnection.Open();
    //Save to SqlServer
    var bulkCopy = new SqlBulkCopy(dbConnection) { DestinationTableName = "YourDatabaseTableName"};
    bulkCopy.WriteToServer(dataTable);
    dbConnection.Close();
