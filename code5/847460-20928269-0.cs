            public static string NextImageName(string filename, int newNumber)
            {
                if (newNumber == 0)
                {
                    return ReplaceOnce(filename, newNumber.ToString(), (filename.Length - 2));
                }
                if (newNumber > 9)
                {
                    return ReplaceOnce(filename, newNumber.ToString(), (filename.Length - 2));
                }
                if (newNumber < 10)
                {
                    return ReplaceOnce(filename, newNumber.ToString(), (filename.Length - 1));
                }
                return filename;
            }
