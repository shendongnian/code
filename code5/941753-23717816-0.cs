    string[] input = Console.ReadLine().Split(' ');
    string text = string.Join("\n", input).Replace("\\t", "\t");
    Console.WriteLine(text);
    File.WriteAllText(@"D:\test.txt", text);
    Console.ReadKey();
