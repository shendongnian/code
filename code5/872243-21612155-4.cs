    var myStringList = new List<string>();
    while (reader.Read())
    {
        var myObject[] = new object[100];
        int colCount = reader.GetValues(myObject);
        for (int i = 0; i < colCount; i++)
        {
            myStringList.Add((string)myObject[i]);
        }
    }
