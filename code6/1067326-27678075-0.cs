    try {
        TextReader tr = new StreamReader("C:\\textfile.txt");
    
            for (int i = 0; i < 4; i++)
            {
                ListLines[i] = tr.ReadLine();
            }
        }
    catch (Exception e)
        {
        Environment.Exit(0)
        }
