            // Setup signature stuff
            var signatureData = new PgpSignatureGenerator(encAlgorithm, hashAlgorithm);
            signatureData.InitSign(PgpSignature.CanonicalTextDocument, privKey);
            foreach (string userId in pubKey.GetUserIds())
            {
                var subPacketGenerator = new PgpSignatureSubpacketGenerator();
                subPacketGenerator.SetSignerUserId(false, userId);
                signatureData.SetHashedSubpackets(subPacketGenerator.Generate());
                // Just the first one!
                break;
            }
            using (var sout = new MemoryStream())
            {
                using (var armoredOut = new ArmoredOutputStream(sout))
                {
                    armoredOut.BeginClearText(hashAlgorithm);
                    using (MemoryStream testIn = new MemoryStream(TEST_DATA, false))
                    {
                        int ch;
                        while ((ch = testIn.ReadByte()) >= 0)
                        {
                            armoredOut.WriteByte((byte)ch);
                            signatureData.Update((byte)ch);
                        }     
                    }
                    armoredOut.EndClearText();
                    using (var outputStream = new BcpgOutputStream(armoredOut))
                    {
                        signatureData.Generate().Encode(outputStream);
                    }
                    byte[] outarr = sout.ToArray();
                    string strOut = System.Text.Encoding.UTF8.GetString(outarr, 0, outarr.Length);
