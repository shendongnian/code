        Dictionary<int, byte[]> results = new Dictionary<int, byte[]>();
        foreach(var grp in data.OrderBy(pair => pair.Key)
                   .GroupBy(pair => (int)pair.Key, pair => pair.Value))
        {
            byte[] result;
            if (grp.Count() == 1)
            {
                result = grp.Single();
            }
            else {
                result = new byte[grp.Sum(arr => arr.Length)];
                int offset = 0;
                foreach(byte[] arr in grp)
                {
                    Buffer.BlockCopy(arr, 0, result, offset, arr.Length);
                    offset += arr.Length;
                }
            }
            results.Add(grp.Key, result);
        }
