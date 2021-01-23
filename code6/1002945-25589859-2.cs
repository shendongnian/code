    List<string> words=new List<string>();
    string[] splittedWords = rich.Text.Split(' ');
    int counter = 0;
    StringBuilder tempWordHolder=new StringBuilder();
    foreach (string word in splittedWords)
    {
        tempWordHolder.Append(" ");
        tempWordHolder.AppendLine(word);
        counter++;
        if (counter > 500)
            continue;
        counter = 0;
        words.Add(tempWordHolder.ToString());
        tempWordHolder.Clear();
    }
    if (tempWordHolder.Length > 0)
    {
        words.Add(tempWordHolder.ToString());
    }
