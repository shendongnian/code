    var pass = "1234567890";
    byte[] salt = Encoding.ASCII.GetBytes(pass.ReverseString());
    //DISABLE YOUR PACK METHOD
    //salt = Pack(pass.ReverseString());
    var hash = PasswordHash.PBKDF2(pass, salt, 1000, 16);
    Console.WriteLine(BitConverter.ToString(hash).Replace("-", string.Empty).ToLower());
    Console.ReadKey();
