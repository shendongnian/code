            private static int[,] FillArrays(string file, int rightLength)
            {
                int[] mArray = File.ReadAllLines(file).Select(x => int.Parse(x)).ToArray();
                int size = mArray.Length / rightLength;
                int[,] arrayDos = new int[size, rightLength];
                int counter = 0;
                int arrayNum = 0;
                foreach (int i in mArray)
                {
                    arrayDos[arrayNum, counter] = i;
                    counter++;
                    if (counter == rightLength)
                    {
                        counter = 0;
                        arrayNum++;
                    }
                }
                return arrayDos;
            }
