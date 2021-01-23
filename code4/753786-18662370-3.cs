			using (Pluralsight.Crypto.CryptContext ctx = new Pluralsight.Crypto.CryptContext()) {
				ctx.Flags = 0x8 | 0x20;
				ctx.Open();
				X509Certificate2 cert = ctx.CreateSelfSignedCertificate(
					new Pluralsight.Crypto.SelfSignedCertProperties
					{
						IsPrivateKeyExportable = true,
						KeyBitLength = 4096,
						Name = new X500DistinguishedName("CN=" + subjectName),
						ValidFrom = DateTime.Today,
						ValidTo = DateTime.Today + expirationLength,
					});
				return cert;
			}
