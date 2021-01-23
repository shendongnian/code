    var file1 = @"C:\Users\User\Desktop\file1.txt";
    var file2 = @"C:\Users\User\Desktop\file2.txt";
    
    var file1Lines = File.ReadLines(file1);
    var file2Text = File.ReadAllText(file2);
    
    var file1WordList = new List<string>();
    var file2WordListWithExtraTenLetters = new List<string>();
    
    foreach (var l in file1Lines)
    {
        file1WordList.AddRange(l.Split(':'));
    }
    
    for (int i = 0; i < file1WordList.Count; i++)
    {
        if (file2Text.Contains(file1WordList[i]))
        {
            var indexOfWordFromFile1InFile2 = file2Text.IndexOf(file1WordList[i]);
            file2WordListWithExtraTenLetters.Add(file2Text.Substring(indexOfWordFromFile1InFile2, 10));
        }
    }
    
    // Test it
    foreach (var element in file1WordList)
    {
        Console.WriteLine(element);
    }
    Console.WriteLine("=====================");
    foreach (var element in file2WordListWithExtraTenLetters)
    {
        Console.WriteLine(element);
    }
