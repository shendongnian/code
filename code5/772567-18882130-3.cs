		private static void EncryptMessage()
		{
			var pubKey = @"<public key text here>";
			var clearText = @"<message text here>";
			using (var stream = pubKey.Streamify())
			{
				var key = stream.ImportPublicKey();
				using (var clearStream = clearText.Streamify())
				using (var cryptoStream = new MemoryStream())
				{
					clearStream.PgpEncrypt(cryptoStream, key);
					cryptoStream.Position = 0;
					var cryptoString = cryptoStream.Stringify();
					Console.WriteLine(cryptoString);
					Console.WriteLine("Press any key to continue.");
				}
			}
			Console.ReadKey();
		}
