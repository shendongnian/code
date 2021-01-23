     // change line 281:
     //  encryptedString = Encoding.UTF8.GetString(encryptedOutStream.ToArray());
     // to:
     encryptedString = Convert.ToBase64String(encryptedOutStream.ToArray());
     
    // change line 251:
    //  using (var encryptedInStream = new MemoryStream(Encoding.UTF8.GetBytes(s)))
    // to:
    using (var encryptedInStream = new MemoryStream(Convert.FromBase64String(s)))
