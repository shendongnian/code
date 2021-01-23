    const int EndOfLine = 2; // CR LF  or = 1 if only LF.
    const int LineLength = 400;
    string text = File.ReadAllText(path);
    for (int i = 0; i < text.Length - EndOfLine; i += LineLength + EndOfLine) {
        string line = text.Substring(i, Math.Min(LineLength, text.Length - i - EndOfLine));
        // TODO Process line
    }
