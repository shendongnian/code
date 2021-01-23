        public int CompareTwoLists(IEnumerable<string> list1, IEnumerable<string> list2)
        {
            var cnt = new Dictionary<string, int>();
            foreach (string s in list1)
            {
                if (cnt.ContainsKey(s))
                {
                    cnt[s]++;
                }
                else
                {
                    cnt.Add(s, 1);
                }
            }
            foreach (string s in list2)
            {
                if (cnt.ContainsKey(s))
                {
                    cnt[s]--;
                }
                else
                {
                    cnt.Add(s, 1);
                }
            }
            //The number returned should determine how much equality exists between your two lists. 
            //If  numberOfEqualElements = yourLists.Length so they are absolutely equal.
            //The accuracy of the approximation = (numberOfEqualElements / yourLists.Length) 
            // 1 = completely equal , 0 = absolutely different, and the values between 0 and 1 determine your accuracy.
            int numberOfEqualElements = cnt.Values.Count(c => c == 0);
            return numberOfEqualElements;
        }
     public double DetermineAccuracyPercentage(int numberOfEqualElements, int yourListsLength)
        {
            return ((double)numberOfEqualElements / (double)yourListsLength) * 100.0; 
        }
