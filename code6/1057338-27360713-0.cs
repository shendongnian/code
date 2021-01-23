               string[] patterns = { "xx0x", "110x", "100x", "010x", "x01x", "1010", "0011", "0111", "1111", "xxxx", "0001", "1010", "0110" };
            
            // - Loop for each input pattern
            foreach (string pattern in patterns)
            {
                // - Count the varying characters and memorize their position
                int wildcardsCount = pattern.Count(x => x == 'x');
                int[] positions = new int[wildcardsCount];
                int index = 0;
                int position = 0;
                foreach (char c in pattern)
                {
                    if (c == 'x')
                        positions[index++] = position;
                    position++;
                }
                // - Loop in all possible values taken by missing bits
                int count = (int)Math.Pow(2, wildcardsCount);
                for (int currentValue = 0; currentValue < count; currentValue++)
                {
                    // - Prepare the binary string
                    string currentValueStr = Convert.ToString(currentValue, 2).PadLeft(wildcardsCount, '0');
                    // - Replace each character with known wildcard positions
                    char[] tmpOutput = pattern.ToCharArray();
                    int charIndex = 0;
                    for (charIndex = 0; charIndex < wildcardsCount; charIndex++)
                        tmpOutput[positions[charIndex]] = currentValueStr[charIndex];
                    string output = new string(tmpOutput);
                    // - Here we are
                    Debug.WriteLine(pattern + " (" + (currentValue + 1).ToString() + "/" + count.ToString() + ") => " + output);
                }
            }
