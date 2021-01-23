    string stringSeparators = "\r\n";
    string text = sr.ReadToEnd();
    string lines = text.Replace(stringSeparators, "");
    lines = lines.Replace("\\r\\n", "\r\n");
    Console.WriteLine(lines);
