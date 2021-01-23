    String strAsymmetricAlgName = SymmetricAlgorithmNames.DesEcbPkcs7;
    SymmetricKeyAlgorithmProvider objAlgProv = SymmetricKeyAlgorithmProvider.OpenAlgorithm(strAsymmetricAlgName);
    CryptographicKey keyPair = objAlgProv.CreateSymmetricKey(CryptographicBuffer.ConvertStringToBinary("key", BinaryStringEncoding.Utf8));
    IBuffer str = CryptographicBuffer.CreateFromByteArray(encodedDataAsBytes);
    IBuffer buf = CryptographicEngine.Decrypt(keyPair, str, null);
    byte[] arr = buf.ToArray();
    string returnValue = System.Text.Encoding.UTF8.GetString(arr, 0, arr.Length);
