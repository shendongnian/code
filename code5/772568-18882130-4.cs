	public static Stream PgpDecrypt(
		this Stream encryptedData,
		string armoredPrivateKey,
		string privateKeyPassword,
		Encoding armorEncoding = null)
	{
		armorEncoding = armorEncoding ?? Encoding.UTF8;
		var stream = PgpUtilities.GetDecoderStream(encryptedData);
		var layeredStreams = new List<Stream> { stream }; //this is to clean up/ dispose of any layered streams.
		var dataObjectFactory = new PgpObjectFactory(stream);
		var dataObject = dataObjectFactory.NextPgpObject();
		Dictionary<long, PgpSecretKey> secretKeys;
		using (var privateKeyStream = armoredPrivateKey.Streamify(armorEncoding))
		{
			var secRings =
				new PgpSecretKeyRingBundle(PgpUtilities.GetDecoderStream(privateKeyStream)).GetKeyRings()
																						   .OfType<PgpSecretKeyRing>();
			var pgpSecretKeyRings = secRings as PgpSecretKeyRing[] ?? secRings.ToArray();
			if (!pgpSecretKeyRings.Any()) throw new ArgumentException("No secret keys found.");
			secretKeys = pgpSecretKeyRings.SelectMany(x => x.GetSecretKeys().OfType<PgpSecretKey>())
										  .ToDictionary(key => key.KeyId, value => value);
		}
		while (!(dataObject is PgpLiteralData) && dataObject != null)
		{
			try
			{
				var compressedData = dataObject as PgpCompressedData;
				var listedData = dataObject as PgpEncryptedDataList;
				//strip away the compression stream
				if (compressedData != null)
				{
					stream = compressedData.GetDataStream();
					layeredStreams.Add(stream);
					dataObjectFactory = new PgpObjectFactory(stream);
				}
				//strip the PgpEncryptedDataList
				if (listedData != null)
				{
					var encryptedDataList = listedData.GetEncryptedDataObjects()
													  .OfType<PgpPublicKeyEncryptedData>().First();
					var decryptionKey = secretKeys[encryptedDataList.KeyId]
						.ExtractPrivateKey(privateKeyPassword.ToCharArray());
					stream = encryptedDataList.GetDataStream(decryptionKey);
					layeredStreams.Add(stream);
					dataObjectFactory = new PgpObjectFactory(stream);
				}
				dataObject = dataObjectFactory.NextPgpObject();
			}
			catch (Exception ex)
			{
				//Log exception here.
				throw new PgpException("Failed to strip encapsulating streams.", ex);
			}
		}
		foreach (var layeredStream in layeredStreams)
		{
			layeredStream.Close();
			layeredStream.Dispose();
		}
		if (dataObject == null) return null;
		var literalData = (PgpLiteralData)dataObject;
		var ms = new MemoryStream();
		using (var clearData = literalData.GetInputStream())
		{
			Streams.PipeAll(clearData, ms);
		}
		ms.Position = 0;
		return ms;
	}
