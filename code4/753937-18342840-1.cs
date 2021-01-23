    HashSet<char> chars = new HashSet<char>();
    string password = "password";
    Int32 count = 0;
    char cUpper;
    foreach (char c in password)
    {
        count++;
        cUpper = char.ToUpper(c);
        if (!chars.Add(char.ToUpper(c))) 
        {
            System.Diagnostics.Debug.WriteLine("not uniue");
            break;
        }
    }
    if(count == chars.Count) System.Diagnostics.Debug.WriteLine("uniue");
