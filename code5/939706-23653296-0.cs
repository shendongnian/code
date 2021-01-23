    // sKey being the encryption key
    
    // adding dirt to the string to make it harder to guess using a dictionary attack.
    byte[] Dirt = Encoding.ASCII.GetBytes(sKey.Length.ToString());
    
    // The Key will be generated from the specified Key and dirt.
    PasswordDeriveBytes FinalKey = new PasswordDeriveBytes(sKey, Dirt);
    
    // to use : FinalKey.GetBytes(16)
