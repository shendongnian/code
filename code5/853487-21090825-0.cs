        static int[] Base64ToIntArray3(string base64, int size)
        {
            if (size < 1 || size > 4) throw new ArgumentOutOfRangeException("size");
            byte[] data = Convert.FromBase64String(base64);
            List<int> res = new List<int>();
            byte[] buffer = new byte[4];
            for (int i = 0; i < data.Length; i += size )
            {
                Buffer.BlockCopy(data, i, buffer, 0, size);
                res.Add(BitConverter.ToInt32(buffer, 0));
            }
            return res.ToArray();
        }
