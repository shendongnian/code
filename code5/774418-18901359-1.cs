    Regex r = new Regex(@"\s");
    String[] tokens = r.Split(tempLineValue);
    string settings = string.Empty;
    for (int i = 0; i < tokens.Length; i++)
    {
       if (tokens[i].Contains(searchTerm))
       {
           settings = tokens[i];
           break;
       }
    }
    if (settings != string.Empty)
        outputWriter.WriteLine((tempLineValue.Replace(settings, replaceTerm));
    else
        outputWriter.WriteLine(tempLineValue);
