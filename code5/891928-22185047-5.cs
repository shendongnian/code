    // First read all the text into a single string.
    string text = File.ReadAllText(FileName);
    // Then split the lines at "\r\n".   
    string[] stringSeparators = new string[] { "\r\n" };
    string[] lines = text.Split(stringSeparators, StringSplitOptions.None);
    // Finally replace lonely '\r' and '\n' by  whitespaces in each line.
    foreach (string s in lines) {
        Console.WriteLine(s.Replace('\r', ' ').Replace('\n', ' '));
    }
