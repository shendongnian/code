    public static string GenerateRandomReference(int length)
        {
            const string chars = "ABCEFGHJKPQRSTXYZ"; 
            const string ints = "23456789"; 
            var returnString = new StringBuilder(length);
            for (int currentIndex = 0; currentIndex < length; currentIndex++)
            {
                if (currentIndex % 2 == 0)
                    //Random letter
                    returnString.Append(chars[RandomHelper.StaticRandom.Instance.Next(chars.Length)]);
                else
                    //Random number
                    returnString.Append(ints[RandomHelper.StaticRandom.Instance.Next(ints.Length)]);
            }
            return returnString.ToString();
        }
