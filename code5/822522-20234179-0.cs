    string line;
    int couinter = 0;
    // Read the file and display it line by line.
    System.IO.StreamReader reader = new System.IO.StreamReader(path);
    System.IO.StreamWriter writer = new System.IO.StreamWriter(new_path);
    while((text = reader.ReadLine()) != null)
    {
       // Check for your content and replace if required here  
       if ( counter == line ) 
          text = targetText;
       writer.writeline(text);
       counter++;
    }
    reader.Close();
    writer.Close();
