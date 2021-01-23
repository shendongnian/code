        public static byte[] ReadFully(Stream input)
        {
            input.Position = 0;//Positioning it to the top of stream.
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
