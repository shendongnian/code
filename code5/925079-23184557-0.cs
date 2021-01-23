        static int characterCount(string s)
        {
            int result = 0;
            foreach (var c in s)
                result += c;
            return result;
        }
    //"test" == 448
