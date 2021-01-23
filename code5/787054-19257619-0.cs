    string[] stringArray = new string[lines + 1];
    using (StreamReader reader = new StreamReader("Name.txt"))
    {
        for (int i = 1; i <= lines; i++)
        {
            stringArray[i - 1] = reader.ReadLine();
        }
    }
