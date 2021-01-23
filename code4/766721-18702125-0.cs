    while (!sr.EndOfStream)
    {
        int a;
        string s = sr.EndOfStream ? "" : sr.ReadLine();
        if (int.TryParse(s, out a))
        {
            // Use the value of a, since it is an integer
        }
        else
        {
            Console.WriteLine(a + " is not a right value");
            flag = true;
            break;
        }
    }
