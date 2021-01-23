      static int GetInt(string value)
        {
            double result = 0d;//double
            IEnumerable<char> target = value.Reverse();
            int index = 0;
            foreach (int c in target)
            {
                if (c != '0')
                    result += (c - '0') * Math.Pow(2, index);
                index++;
            }
            return (int)result;
        }
