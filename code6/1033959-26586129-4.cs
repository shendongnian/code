    line1_1 /*First line*/
    line1_2
    line1_3
    line2_1 /*second line*/
    line2_2
    line2_3
    line3_1 /*third line*/
    line3_2
    line3_3
    line4_1 /*fourth line*/
    line4_2
    line4_3
    string result = String.Empty;
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
					result += line; 
                }
        }   
		result.Dump(); /*LinqPad Only*/
