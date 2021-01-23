            var indecies =new byte[Bytes.Length];
            for (byte i = 0; i < Bytes.Length; i++)
            {
                indecies[i] = i;
            }
            int n = Bytes.Length;
            while (n > 1)
            {
                n--;
                int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                byte value = Bytes[k];
                byte index = indecies[k];
                Bytes[k] = Bytes[n];
                indecies[k] = indecies[n];
                Bytes[n] = value;
                indecies[n] = index;
            }
