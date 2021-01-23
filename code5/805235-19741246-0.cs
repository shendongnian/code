    int counter = 0;
    bool writeNextLine = false;
    string line;
    
    // Read the file and display it line by line.
    System.IO.StreamReader file = new System.IO.StreamReader("test.txt");
    while ((line = file.ReadLine()) != null)
    {
        if (writeNextLine) 
        {
            Console.WriteLine(line); 
        }
        writeNextLine = line.Contains("word");    
        counter++;
    }
    
    file.Close();
