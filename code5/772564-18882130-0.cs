	public static class OpenPgpUtility
	{
		public static void ExportKeyPair(
			Stream secretOut,
			Stream publicOut,
			AsymmetricKeyParameter publicKey,
			AsymmetricKeyParameter privateKey,
			string identity,
			char[] passPhrase,
			bool armor)
		{
			if (armor)
			{
				secretOut = new ArmoredOutputStream(secretOut);
			}
			var secretKey = new PgpSecretKey(
				PgpSignature.DefaultCertification,
				PublicKeyAlgorithmTag.RsaGeneral,
				publicKey,
				privateKey,
				DateTime.UtcNow,
				identity,
				SymmetricKeyAlgorithmTag.Cast5,
				passPhrase,
				null,
				null,
				new SecureRandom()
				);
			secretKey.Encode(secretOut);
			if (armor)
			{
				secretOut.Close();
				publicOut = new ArmoredOutputStream(publicOut);
			}
			var key = secretKey.PublicKey;
			key.Encode(publicOut);
			if (armor)
			{
				publicOut.Close();
			}
		}
		public static PgpPublicKey ImportPublicKey(
			this Stream publicIn)
		{
			var pubRings =
				new PgpPublicKeyRingBundle(PgpUtilities.GetDecoderStream(publicIn)).GetKeyRings().OfType<PgpPublicKeyRing>();
			var pubKeys = pubRings.SelectMany(x => x.GetPublicKeys().OfType<PgpPublicKey>());
			var pubKey = pubKeys.FirstOrDefault();
			return pubKey;
		}
		public static PgpSecretKey ImportSecretKey(
			this Stream secretIn)
		{
			var secRings =
				new PgpSecretKeyRingBundle(PgpUtilities.GetDecoderStream(secretIn)).GetKeyRings().OfType<PgpSecretKeyRing>();
			var secKeys = secRings.SelectMany(x => x.GetSecretKeys().OfType<PgpSecretKey>());
			var secKey = secKeys.FirstOrDefault();
			return secKey;
		}
		public static Stream Streamify(this string theString, Encoding encoding = null)
		{
			encoding = encoding ?? Encoding.UTF8;
			var stream = new MemoryStream(encoding.GetBytes(theString));
			return stream;
		}
		public static string Stringify(this Stream theStream,
									   Encoding encoding = null)
		{
			encoding = encoding ?? Encoding.UTF8;
			using (var reader = new StreamReader(theStream, encoding))
			{
				return reader.ReadToEnd();
			}
		}
		public static byte[] ReadFully(this Stream stream, int position = 0)
		{
			if (!stream.CanRead) throw new ArgumentException("This is not a readable stream.");
			if (stream.CanSeek) stream.Position = 0;
			var buffer = new byte[32768];
			using (var ms = new MemoryStream())
			{
				while (true)
				{
					var read = stream.Read(buffer, 0, buffer.Length);
					if (read <= 0)
						return ms.ToArray();
					ms.Write(buffer, 0, read);
				}
			}
		}
		public static void PgpEncrypt(
			this Stream toEncrypt,
			Stream outStream,
			PgpPublicKey encryptionKey,
			bool armor = true,
			bool verify = false,
			CompressionAlgorithmTag compressionAlgorithm = CompressionAlgorithmTag.Zip)
		{
			var encryptor = new PgpEncryptedDataGenerator(SymmetricKeyAlgorithmTag.Cast5, verify, new SecureRandom());
			var literalizer = new PgpLiteralDataGenerator();
			var compressor = new PgpCompressedDataGenerator(compressionAlgorithm);
			encryptor.AddMethod(encryptionKey);
			//it would be nice if these streams were read/write, and supported seeking.  Since they are not,
			//we need to shunt the data to a read/write stream so that we can control the flow of data as
			//we go.
			using (var stream = new MemoryStream()) // this is the read/write stream
			using (var armoredStream = armor ? new ArmoredOutputStream(stream) : stream as Stream)
			using (var compressedStream = compressor.Open(armoredStream))
			{
				//data is encrypted first, then compressed, but because of the one-way nature of these streams,
				//other "interim" streams are required.  The raw data is encapsulated in a "Literal" PGP object.
				var rawData = toEncrypt.ReadFully();
				var buffer = new byte[1024];
				using (var literalOut = new MemoryStream())
				using (var literalStream = literalizer.Open(literalOut, 'b', "STREAM", DateTime.UtcNow, buffer))
				{
					literalStream.Write(rawData, 0, rawData.Length);
					literalStream.Close();
					var literalData = literalOut.ReadFully();
					//The literal data object is then encrypted, which flows into the compressing stream and
					//(optionally) into the ASCII armoring stream.
					using (var encryptedStream = encryptor.Open(compressedStream, literalData.Length))
					{
						encryptedStream.Write(literalData, 0, literalData.Length);
						encryptedStream.Close();
						compressedStream.Close();
						armoredStream.Close();
						//the stream processes are now complete, and our read/write stream is now populated with 
						//encrypted data.  Convert the stream to a byte array and write to the out stream.
						stream.Position = 0;
						var data = stream.ReadFully();
						outStream.Write(data, 0, data.Length);
					}
				}
			}
		}
	}
