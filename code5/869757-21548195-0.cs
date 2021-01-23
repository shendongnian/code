    string s = "*This is a string *with more than *one blocks *of values.";
    string[] splitted = s.Split(new char[] { '*' }, StringSplitOptions.RemoveEmptyEntries);
    string result = "";
    foreach (string split in splitted)
        if (!string.IsNullOrEmpty(split))
            result += split[0];
    Console.WriteLine(result);
