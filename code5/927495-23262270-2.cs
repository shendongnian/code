    void Main()
    {
    	string lines = "First line.\r\nSecond line.\r\nThird line.";
    	var = new System.IO.StreamWriter("c:\\test_eng.txt");
    	file.WriteLine(lines);
    	file.Close();
    	
    	string hebrew = @"מספרים רצים מימין לשמאל ?";
    	file = new System.IO.StreamWriter("c:\\test_heb.txt");
    	file.WriteLine(hebrew);
    	file.Close();
    }
