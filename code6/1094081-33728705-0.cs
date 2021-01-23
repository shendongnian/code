    public Tuple<byte[],byte[]> GetPublicKey(byte[] privateKey)
	{
		BigInteger privKeyInt = new BigInteger(+1, privateKey);
		var parameters = SecNamedCurves.GetByName("secp256k1");
		ECPoint qa = parameters.G.Multiply(privKeyInt);
		byte[] pubKeyX = qa.X.ToBigInteger().ToByteArrayUnsigned();
		byte[] pubKeyY = qa.Y.ToBigInteger().ToByteArrayUnsigned();
		return Tuple.Create(pubKeyX, pubKeyY);
	}
