    HashSet<char> chars = new HashSet<char>();
    string password = "password";
    Int32 count = 0;
    char cUpper;
    foreach (char c in password)
    {
        count++;        
        cUpper = char.ToUpper(c);
        if (chars.Contains(cUpper))
        {
            System.Diagnostics.Debug.WriteLine("not uniue");
            break;
        }
        chars.Add(char.ToUpper(cUpper));
    }
    if(count == chars.Count) System.Diagnostics.Debug.WriteLine("uniue");
