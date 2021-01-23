    public static class Utility
        {
            // '۰' = 1632
            // '0' = 48
            // ------------
            //  1632  => '۰'
            //- 1584
            //--------
            //   48   => '0'
            public static string GetEnglish(this string input)
            {
                char[] persianDigitsAscii = input.ToCharArray(); //{ 1632, 1633, 1634, 1635, 1636, 1637, 1638, 1639, 1640, 1641 };
                string output = "";
                for (int k = 0; k < persianDigitsAscii.Length; k++)
                {
                    persianDigitsAscii[k] = (char) (persianDigitsAscii[k] - 1584);
                    output += persianDigitsAscii[k];
                }
    
                 return output;
            }
        }
