        string dir = System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location);
        string path = dir + @"\zip_code_database_edited.csv";
        var open = new StreamReader(File.OpenRead(path));
        var cities = new HashList<string>();
        var zipCodes = new HashList<int>();
        var zipAndCity = new string[2];
        string line = string.Empty;
        using (open)
	{
            while ((line = reader.ReadLine()) != null)
	        {
	            zipAndCity = line.Split(",");
                    zipCodes.Add(int.Parse(zipAndCity[0]));
                    cities.Add(zipAndCity[1]);   
            }
            
	}
