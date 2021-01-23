            byte[] bytes = new byte[1024];
            byte[] buffer = new byte[1024];
            ICryptoTransform transform = null;
            MemoryStream stream = null;
            try
            {
                stream = new MemoryStream();
                using (CryptoStream cs = new CryptoStream(stream, transform, CryptoStreamMode.Write))
                {
                    cs.Write(buffer, 0, buffer.Length);
                    bytes = stream.ToArray();
                    stream = null;
                }
            }
            finally
            {
                if (stream != null)
                {
                    stream.Dispose();
                }
            }
            return bytes;
