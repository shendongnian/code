    var words = new Dictionary<char, string>();
    words.Add('a', "Alpha");
    words.Add('b',"Beta");
    ...
    string input = Console.ReadLine();
    string[] contents = new string[input.Length];
    for (int i = 0; i < input.Length; i++)
    {
         if (words.ContainsKey(input[i]))
         {
             contents[i] = words[input[i]];
         }
    }
    string result = string.Join(" ", contents);
