    var sb = new StringBuilder();
    for (int index = 0; index < userText.Length; index++)
    {
        var t = userText[index].ToLower();
        string morseValue;
        // no need for ContainsKey/[], use a single lookup
        if (morseCode.TryGetValue(t, out morseValue))
        {
            sb.Append(morseValue);
        }
    }
    outLabel.Text = sb.ToString();
