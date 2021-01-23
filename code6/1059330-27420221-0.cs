        public IEnumerable<string[]> GetChunk(string[] input, int size)
        {
            int i = 0;
            while (input.Length > size * i)
            {
                yield return input.Skip(size * i).Take(size).ToArray();
                i++;
            }
        }
