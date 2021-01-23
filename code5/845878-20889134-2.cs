    var fileNames = System.IO.Directory.GetFiles(your folder);
    int number = 0;
    string currentFile = string.Empty;
    foreach (var item in fileNames)
    {
        if (item.StartsWith("food_"))
        {
            int temp = int.Parse(item.Skip(5).ToString());
            if (temp>number){number=temp; currentFile = item;}
        }
    }
