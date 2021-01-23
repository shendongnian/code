    // Read the file and display it line by line.
    System.IO.StreamReader file = 
       new System.IO.StreamReader("c:\\test.txt");
    while((line = file.ReadLine()) != null)
    {
    	 string[] words = s.Split('|');
        string value = words [8]
       Console.WriteLine (value);
      
    }
    
    file.Close();
