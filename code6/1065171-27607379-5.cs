    while ((line = file.ReadLine()) != null)
    {
        i++;
        if (i>=1000 && i<=2000 && line.Contains("mySecretWord"))
        {
            System.Console.WriteLine("YES");
            System.Console.WriteLine(i);
            break;
        }
    }
