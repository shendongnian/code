    string textToCompare = "word banana tree more words";
    for (int i = 0; i < listViewInput.Items.Count; i++)
    {
        string regex = `\b'+listViewInput.Items[i].Text[i]+'\b`  // e.g. `\bbanana\b`
        if (Regex.IsMatch(textToCompare,regex ))
        {
            listViewOutput.Items.Add(listViewInput.Items[i].Text);
        }
    }
