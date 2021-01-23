    public Tuple<byte[],byte[]> GetPublicKey(byte[] privateKey){
        BigInteger privKeyInt = new BigInteger(+1, privateKey);
        var parameters = SecNamedCurves.GetByName("secp256k1");
        ECPoint qa = parameters.G.Multiply(privKeyInt).Normalize();
        byte[] pubKeyX = qa.XCoord.ToBigInteger().ToByteArrayUnsigned();
        byte[] pubKeyY = qa.YCoord.ToBigInteger().ToByteArrayUnsigned();
        return Tuple.Create(pubKeyX, pubKeyY);
    }
