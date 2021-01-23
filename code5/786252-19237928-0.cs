    [TestMethod]
            public void RandomizeText()
            {
                string baseList = "abcdefghijklmnopqrstuvwxyz";
                char[] result = baseList.ToCharArray();
                Shuffle<char>(result);
                var final = string.Join("", result);
                final.Should().NotMatch(baseList);
    
            }
        public void Shuffle<T>(T[] array)
        {
            var random = new Random();
            for (int x = 0; x < 100; x++)
            {
                for (int i = array.Length; i > 1; i--)
                {
                    // Pick random element to swap.
                    int j = random.Next(i); // 0 <= j <= i-1
                    // Swap.
                    T tmp = array[j];
                    array[j] = array[i - 1];
                    array[i - 1] = tmp;
                }
            }
        }
