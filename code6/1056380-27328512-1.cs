        public static void TestPermutations()
        {
            int [][] seqence = new int [][]
            {
                new int [] {1, 2, 3},
                new int [] {101},
                new int [] {201},
                new int [] {301, 302, 303},
            };
            foreach (var array in seqence.Permutations(a => a))
            {
                Debug.WriteLine(array.Aggregate(new StringBuilder(), (sb, i) => { if (sb.Length > 0) sb.Append(","); sb.Append(i); return sb; }));
            }
        }
