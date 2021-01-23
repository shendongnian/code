    byte[] decodedtext = Convert.FromBase64String(querystring);
    byte[] decrypted = Encryption.Decrypt(decodedtext, key);
    string plaintext = ASCIIEncoding.UTF8.GetString(decrypted);
    State mystate = new State();
    mystate.Deserialize(plaintext);
    return mystate;
