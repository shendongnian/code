    foreach (Match m in matches)
    {
        Console.WriteLine(m.Groups[1]);
         string[] words = m.Groups[1].Value.Split('/');
         foreach (string word in words)
            Console.WriteLine(word);
    }
