    string str = "test";
    int counter = 0;
    try
    {
        for (int i = 0; ; i++)
        {
            char temp = str[i];
            counter++;
        }
    }
    catch(IndexOutOfRangeException ex)
    {
    }
    Console.WriteLine(counter);
