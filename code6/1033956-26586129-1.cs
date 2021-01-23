    List<string>result = new List<string>();
	string location = @"c:\users\asdsad\desktop\lines.txt";
	if (System.IO.File.Exists(location) == true)
        {
            using (StreamReader reader = new StreamReader(location))
            {
				string line = String.Empty;
                while ((line = reader.ReadLine()) != null) /*line has the first line in it*/
                {
					for(int i = 0; i<2; i++) /*only iterate to 2 because we need only the next 2 lines*/
                        line += reader.ReadLine(); /*use StringBuilder if you like*/
					result.Add(line); /*Add to TargetCollection*/
                }
        }   
		result.Dump(); /*LinqPad Only*/
