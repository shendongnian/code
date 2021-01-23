        static int[] Base64ToIntArray3(string base64, int size)
        {
            byte[] data = Convert.FromBase64String(base64);
            return data.Select((Value, Index) => new { Value, Index })
                       .GroupBy(p => p.Index / size)
                       .Select(g => BitConverter.ToInt32(g.Select(p => p.Value).Union(new byte[4 - size]).ToArray(), 0))
                       .ToArray();
        }
