    public static int RandomIndexOf<T>(this IList<T> sequence, T element)
            {
                Random rnd = new Random();
                List<int> matchedIndexs = new List<int>();
                for (int i = 0; i < sequence.Count; i++)
                {
                    if (sequence[i].Equals(element))
                        matchedIndexs.Add(i);
                }
                return matchedIndexs[rnd.Next(matchedIndexs.Count)];
            }
