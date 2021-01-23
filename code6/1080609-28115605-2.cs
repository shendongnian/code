    content = File.ReadAllText(documentPath);
    var paragraphs = content.split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
    string[][] results = new string[paragraphs.Length][];
    for(int i = 0; i < results.Length; i++)
    {
        results[i] = paragraphs[i].Split(new char[] {'.'}, StringSplitOptions.RemoveEmptyEntries);
    }
You can avoid having to use the Regex by using the StringSplitOptions.RemoveEmptyEntries configuration option as it will remove all strings that only contain whitespace, \n strings included.
Now, accessing results[0] will give you an array of all strings in paragraph one and so on. 
