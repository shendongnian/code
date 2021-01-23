    /// <summary>
        /// Gets the bitmap image color statistics
        /// </summary>
        /// <param name="bit">The bitmap image you want to analyze</param>
        /// <returns></returns>
        public static List<KeyValuePair<Color, int>> GetStatistics(Bitmap bit)
        {
            Dictionary<Color, int> countDictionary = new Dictionary<Color, int>();
            for (int wid = 0; wid < bit.Width; wid++)
            {//for every column in the image
                for (int he = 0; he < bit.Height; he++)
                {//for every row in the image
                    //Get the color of the pixel reached (i.e. at the current column and row)
                    Color currentColor = bit.GetPixel(wid, he);
                    //If a record already exists for this color, set the count, otherwise just set it as 0
                    int currentCount = (countDictionary.ContainsKey(currentColor) ? countDictionary[currentColor] : 0);
                    if (currentCount == 0)
                    {//If this color doesnt already exists in the dictionary, add it
                        countDictionary.Add(currentColor, 1);
                    }
                    else
                    {//If it exists, increment the value and update it
                        countDictionary[currentColor] = currentCount + 1;
                    }
                }
            }
            //order the list from most used to least used before returning
            List<KeyValuePair<Color, int>> l = countDictionary.OrderByDescending(o => o.Value).ToList();
            return l;
        }
    }
