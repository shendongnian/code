    String line = String.Empty;
    System.IO.StreamReader file =  new System.IO.StreamReader("c:\\file.txt");
    while((line = file.ReadLine()) != null)
    {
        String[] parts_of_line = line.Split(',')
        for ( int i = 0; i < parts_of_line.Length; i++ )
            parts_of_line[i] = parts_of_line[i].Trim();
    
        // do with the parts of the line whatever you like
    
    }
