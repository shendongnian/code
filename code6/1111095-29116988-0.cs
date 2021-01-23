    FileStream fs = File.OpenRead("C:\\your-file.txt");
    string[] lines = new StreamReader(fs).ReadToEnd().Split(
             new string[]{"\r\n", "\r", "\n"}, 
             StringSplitOptions.RemoveEmptyEntries);
    fs.Close();
    List<string> list2 = new List<string>();
    for (int i = 0; i < lines.Length; i++)
    {
        char[] chars = lines[i].ToCharArray();
        for (int j = 0; j < chars.Length; j++)
        {
            if (!Char.IsWhiteSpace(chars[j]))
                list2.Add(chars[j].ToString());
        }
    }
