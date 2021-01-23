    int counter = 0;
    string line;
    System.IO.StreamReader file = new System.IO.StreamReader("test.txt");
    while ((line = file.ReadLine()) != null)
    {
        if (line.Contains("word"))
        {
            if ((line = file.ReadLine()) != null)
                Console.WriteLine(line);
        }
        counter++;
    }
    file.Close();
