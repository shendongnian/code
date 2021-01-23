    byte[] passwordBytes = Encoding.Unicode.GetBytes(userTypedPassword);
    //
    // This is where you'd normally append or prepend the salt bytes
    //
    var hasher = System.Security.CryptographySHA256.Create();
    byte[] hashedBytes = hasher.ComputeHash(passwordBytes);
