    string sha1(string input) {
        byte[] byteArray = Encoding.UTF8.GetBytes(input);
        string result="";
        using (HashAlgorithm hash = SHA1.Create()) {
            result=Convert.ToBase64String(hash.ComputeHash(byteArray);
        }
        return result;
    }
