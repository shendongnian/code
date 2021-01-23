    // the encryption output should be: da02ce3a89ecac3b
    // But I'm getting this output instead: 019945B853663D50
    string inputString = "02468aceeca86420";
    string stringkey = "0f1571c947d9e859";
    string encryptedReference = "da02ce3a89ecac3b";
    string siv = "0000000000000000";
    encryptedString = DesCsp.EncryptHexStrings(inputString, stringkey, siv);
    decryptedString = DesCsp.DecryptHexStrings(encryptedString, stringkey, siv);
    Debug.Assert(inputString.ToUpper() == decryptedString.ToUpper());
    Debug.Assert(encryptedString.ToUpper() == encryptedReference.ToUpper());
