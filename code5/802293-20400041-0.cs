        public static void CheckSignedMessage(string message, string sig64)
        {
            byte[] sigBytes = Convert.FromBase64String(sig64);
            byte[] msgBytes = FormatMessageForSigning(message);
            int first = (sigBytes[0] - 27);
            bool comp = (first & 4) != 0;
            int rec = first & 3;
            BigInteger[] sig = ParseSig(sigBytes, 1);
            byte[] msgHash = DigestUtilities.CalculateDigest("SHA-256", DigestUtilities.CalculateDigest("SHA-256", msgBytes));
            ECPoint Q = Recover(msgHash, sig, rec, true);
            byte[] qEnc = Q.GetEncoded(comp);
            Console.WriteLine("Q: " + Hex.ToHexString(qEnc));
            byte[] qHash = DigestUtilities.CalculateDigest("RIPEMD-160", DigestUtilities.CalculateDigest("SHA-256", qEnc));
            Console.WriteLine("RIPEMD-160(SHA-256(Q)): " + Hex.ToHexString(qHash));
            Console.WriteLine("Signature verified correctly: " + VerifySignature(Q, msgHash, sig));
        }
        public static BigInteger[] ParseSig(byte[] sigBytes, int sigOff)
        {
            BigInteger r = new BigInteger(1, sigBytes, sigOff, 32);
            BigInteger s = new BigInteger(1, sigBytes, sigOff + 32, 32);
            return new BigInteger[] { r, s };
        }
        public static ECPoint Recover(byte[] hash, BigInteger[] sig, int recid, bool check)
        {
            X9ECParameters x9 = SecNamedCurves.GetByName("secp256k1");
            BigInteger r = sig[0], s = sig[1];
            FpCurve curve = x9.Curve as FpCurve;
            BigInteger order = x9.N;
            BigInteger x = r;
            if ((recid & 2) != 0)
            {
                x = x.Add(order);
            }
            if (x.CompareTo(curve.Q) >= 0) throw new Exception("X too large");
            byte[] xEnc = X9IntegerConverter.IntegerToBytes(x, X9IntegerConverter.GetByteLength(curve));
            byte[] compEncoding = new byte[xEnc.Length + 1];
            compEncoding[0] = (byte)(0x02 + (recid & 1));
            xEnc.CopyTo(compEncoding, 1);
            ECPoint R = x9.Curve.DecodePoint(compEncoding);
            if (check)
            {
                //EC_POINT_mul(group, O, NULL, R, order, ctx))
                ECPoint O = R.Multiply(order);
                if (!O.IsInfinity) throw new Exception("Check failed");
            }
            BigInteger e = CalculateE(order, hash);
            BigInteger rInv = r.ModInverse(order);
            BigInteger srInv = s.Multiply(rInv).Mod(order);
            BigInteger erInv = e.Multiply(rInv).Mod(order);
            return ECAlgorithms.SumOfTwoMultiplies(R, srInv, x9.G.Negate(), erInv);
        }
        public static bool VerifySignature(ECPoint Q, byte[] hash, BigInteger[] sig)
        {
            X9ECParameters x9 = SecNamedCurves.GetByName("secp256k1");
            ECDomainParameters ec = new ECDomainParameters(x9.Curve, x9.G, x9.N, x9.H, x9.GetSeed());
            ECPublicKeyParameters publicKey = new ECPublicKeyParameters(Q, ec);
            return VerifySignature(publicKey, hash, sig);
        }
        public static bool VerifySignature(ECPublicKeyParameters publicKey, byte[] hash, BigInteger[] sig)
        {
            ECDsaSigner signer = new ECDsaSigner();
            signer.Init(false, publicKey);
            return signer.VerifySignature(hash, sig[0], sig[1]);
        }
        private static BigInteger CalculateE(
            BigInteger n,
            byte[] message)
        {
            int messageBitLength = message.Length * 8;
            BigInteger trunc = new BigInteger(1, message);
            if (n.BitLength < messageBitLength)
            {
                trunc = trunc.ShiftRight(messageBitLength - n.BitLength);
            }
            return trunc;
        }
        public static byte[] FormatMessageForSigning(String message)
        {
            MemoryStream bos = new MemoryStream();
            bos.WriteByte((byte)BITCOIN_SIGNED_MESSAGE_HEADER_BYTES.Length);
            bos.Write(BITCOIN_SIGNED_MESSAGE_HEADER_BYTES, 0, BITCOIN_SIGNED_MESSAGE_HEADER_BYTES.Length);
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            //VarInt size = new VarInt(messageBytes.length);
            //bos.write(size.encode());
            // HACK only works for short messages (< 253 bytes)
            bos.WriteByte((byte)messageBytes.Length);
            bos.Write(messageBytes, 0, messageBytes.Length);
            return bos.ToArray();
        }
