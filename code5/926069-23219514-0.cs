    string output = Regex.Replace(text, @"\r?\n(?!:)", " ");
    string[] lines = output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
    foreach (string line in lines)
    {
        if (line.StartsWith(":58A:"))
        {
        }
        else if (line.StartsWith(":72:"))
        {
        }
    }
