    using (var rsa = new RSACryptoServiceProvider(cp))
    {
        var keyPair = DotNetUtilities.GetKeyPair(rsa);
        var publicKeyInfo = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(keyPair.Public);
        var serializedPublicBytes = publicKeyInfo.GetEncoded();
        return BitConverter.ToString(serializedPublicBytes).Replace("-", "");
    }
