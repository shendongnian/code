    try
    {
        string str1 = @"C:\Users\XXXXX\Desktop\testfile";
        string str3 = ".datafile";
        for (int i = 0; i < 3; i++)
        {
            for(int j = 0; j< 3; j++){               
      
                string final = str1 + i+ j + str3;
                var lines = File.ReadLines(final)
                            .SkipWhile(line => !line.Contains("#Footer"))
                            .Skip(1)
                            .ToList();
                Console.WriteLine(String.Join(Environment.NewLine, lines));
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("The file could not be read:");
        Console.WriteLine(e.Message);
        Console.Read();
    }
