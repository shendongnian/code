    int counter = 0;
    string line;
    // Read the file and display it line by line.
    System.IO.StreamReader file = new System.IO.StreamReader("c:\\test.txt");
    while((line = file.ReadLine()) != null)
    {
       Console.WriteLine (line);
       //Do some logic with the readed line
       counter++;
    }
    file.Close();
