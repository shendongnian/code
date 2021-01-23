        var i = 0;
        var @from = 1000;
        var to = 2000;
        while ((line = file.ReadLine()) != null)
        {
            i++;
            if (i < @from)
                continue;
            if (i > to)
                break;
            if (line.Contains("mySecretWord"))
            {
                System.Console.WriteLine("YES");
                System.Console.WriteLine(i);
                break;
            }
        }
