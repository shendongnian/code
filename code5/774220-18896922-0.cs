    string readText = File.ReadAllText(path);
    string[] lines = readText.Split(Environment.NewLine);
    string output;
    foreach(string line in lines)
    {
        int pos = text.IndexOf("t");
        if(pos>0)
           text = text.Replace("t", "Success");
        output += text + Environment.NewLine;
    }
    File.AppendAllText(newPath, output);
