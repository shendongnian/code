        var bytesToDecrypt = Convert.FromBase64String(string64); // string to decrypt, base64 encoded
        AsymmetricCipherKeyPair keyPair;
        using (var reader = File.OpenText(@"C:\Users\Diego\Documents\private.pem"))
            keyPair = (AsymmetricCipherKeyPair)new Org.BouncyCastle.OpenSsl.PemReader(reader).ReadObject();
        var decryptEngine = new Pkcs1Encoding(RsaEngine());
        decryptEngine.Init(false, keyPair.Private);
        var decrypted = Encoding.UTF8.GetString(decryptEngine.ProcessBlock(bytesToDecrypt, 0, bytesToDecrypt.Length));
        Logs.Log.LogMessage("decrypted: " + decrypted);
        System.Windows.MessageBox.Show(decrypted);
