        public string ExportPrivateKey(RSA rsa)
        {
            var privateKeyBytes = rsa.ExportRSAPrivateKey();
            var builder = new StringBuilder("-----BEGIN RSA PRIVATE KEY");
            builder.AppendLine("-----");
            var base64PrivateKeyString = Convert.ToBase64String(privateKeyBytes);
            var offset = 0;
            const int LINE_LENGTH = 64;
            while (offset < base64PrivateKeyString.Length)
            {
                var lineEnd = Math.Min(offset + LINE_LENGTH, base64PrivateKeyString.Length);
                builder.AppendLine(base64PrivateKeyString.Substring(offset, lineEnd - offset));
                offset = lineEnd;
            }
            builder.Append("-----END PRIVATE KEY");
            builder.AppendLine("-----");
            return builder.ToString();
        }
