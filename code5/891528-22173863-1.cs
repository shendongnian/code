    int index = String2.IndexOf(String1);
    if(index >= 0)
    {
        string result = String1;
        if (String1.Length < String2.Length)
        {
            string rest = String2.Substring(index + String1.Length);
            var chars = rest.TakeWhile(c => !Char.IsLetter(c) && !Char.IsWhiteSpace(c));
            result = result + string.Join("", chars);
        }
    }
