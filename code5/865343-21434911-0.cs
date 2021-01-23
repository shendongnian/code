    // Setup XML formatting
    XmlWriterSettings xws = new XmlWriterSettings();
    xws.Encoding = Encoding.UTF8;
    xws.Indent = true;
    xws.IndentChars = "\t";
    xws.OmitXmlDeclaration = false;
    // Encrypt document to file
    byte[] salt = new byte[8];
    new RNGCryptoServiceProvider().GetBytes(salt);
    Rfc2898DeriveBytes keyGenerator = new Rfc2898DeriveBytes(password, salt);
    using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
    {
        aes.Key = keyGenerator.GetBytes(aes.KeySize / 8);
        using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
        using (CryptoStream cs = new CryptoStream(fs, aes.CreateEncryptor(), CryptoStreamMode.Write))
        using (StreamWriter sw = new StreamWriter(cs, Encoding.UTF8))
        {
            fs.Write(salt, 0, salt.Length);
            fs.Write(aes.IV, 0, aes.IV.Length);
            // Write XmlDocument to the encrypted file
            XmlWriter writer = XmlWriter.Create(sw, xws);
            xdoc.Save(writer);
            writer.Close();
        }
    }
    // Decrypt the file
    using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
    {
        byte[] salt = new byte[8];
        fs.Read(salt, 0, salt.Length);
        Rfc2898DeriveBytes keyGenerator = new Rfc2898DeriveBytes(this.password, salt);
        using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
        {
            aes.Key = keyGenerator.GetBytes(aes.KeySize / 8);
            byte[] iv = new byte[aes.BlockSize / 8];
            fs.Read(iv, 0, iv.Length);
            aes.IV = iv;
            using (CryptoStream cs = new CryptoStream(fs, aes.CreateDecryptor(), CryptoStreamMode.Read))
            using (StreamReader sr = new StreamReader(cs))
            {
                // Read stream into new XmlDocument
                xdoc.Load(sr);
            }
        }
    }
