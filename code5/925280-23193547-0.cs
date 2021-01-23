    public Dictionary<Color, int> GetStatistics(Bitmap bit)
        {
            Dictionary<Color, int> countDictionary = new Dictionary<Color, int>();
            for (int wid = 0; wid < bit.Width; wid++)
            {
                for (int he = 0; he < bit.Height; he++)
                {
                    Color currentColor = bit.GetPixel(wid, he);
                    int currentCount = (countDictionary.ContainsKey(currentColor) ? countDictionary[currentColor] : 0);
                    countDictionary.Add(currentColor, currentCount + 1);
                }
            }
            countDictionary.OrderBy(ord => ord.Value);
            return countDictionary;
        }
