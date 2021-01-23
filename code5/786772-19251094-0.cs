        private byte[] Max(byte[][] arrBytes)
        {
            byte[] max = new byte[arrBytes.GetLength(0)];
            int i = 0;
            foreach (byte[] arr in arrBytes)
            {
                byte m = 0;
                foreach (byte b in arr)
                {
                    m = Math.Max(m, b);
                }
                max[i] = m; ++i;
            }
            return max;
        }
