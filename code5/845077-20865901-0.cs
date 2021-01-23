      while (a[0].Length > 0 || a[0].Length != 0)
            {
                NumberOfChars = a[0].Length;
                if (NumberOfChars < 100)
                {
                    r = NumberOfChars;
                }
                else if (NumberOfChars == 100)
                {
                    r = 100;
                }
                else if (NumberOfChars > 100)
                {
                    r = 100;
                }
                decimal numberOfTweetsUnRounded = a[0].Length/100M; 
                if (numberOfTweetsUnRounded == 0)
                {
                    numberOfTweetsUnRounded = 1;
                }
                int numberOfTweetsRounded = Convert.ToInt32(Math.Ceiling(numberOfTweetsUnRounded));
                int numberOfSpaces = 0;
                int indexOfSpaces = 0;
                int indexOfCChars = 0;
                int indexPointOfSplit = 0;
                for (int i = 1; i <= numberOfTweetsRounded; i++)
                {
                    if (r == 100)
                    {
                        string firstItem = a[0].Substring(0, 100);
                        for (int pos = 0; pos < firstItem.Length; pos++)
                        {
                            if (!Char.IsWhiteSpace(firstItem[pos]))
                                continue;
                            indexOfSpaces++;
                            indexPointOfSplit = pos;
                        }
                    }
                    //When I split the string, it doesn't work. It gives an error of the index being outside the range.
                    string breakOff = a[0].Substring(0, indexPointOfSplit);
                }
                a[0] = a[0].Remove(0, indexPointOfSplit);
                builder.Clear();
                NumberOfChars = a[0].Length;
            }
