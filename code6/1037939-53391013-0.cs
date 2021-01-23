        static void Main(string[] args)
        {
            var a = new int[6] { 3, 5, 6, 3, 3, 5 };
            //Push the indices into an array:
            int[] indices = new int[a.Count()];
            for (int p = 0; p < a.Count(); ++p) indices[p] = p;
            //Sort the indices according to the value of the corresponding element in a:
            Array.Sort(indices, (k, l) =>Compare(a[k], a[l]));
            //Then just pull out blocks of indices with equal corresponding elements from indices:
            int count = 0;
            int i = 0;
            while (i < indices.Count())
            {
                int start = i;
                while (i < indices.Count() && a[indices[i]] == a[indices[start]])
                {
                    ++i;
                }
                int thisCount = i - start;
                int numPairs = thisCount * (thisCount - 1) / 2;
                count += numPairs;
            }
            Console.WriteLine(count);
            Console.ReadKey();
            
        }
        //Compare function to return interger
        private static int Compare(int v1, int v2)
        {
            if (v2 > v1)
                return 1;
            if (v1 == v2)
                return 0;
            else
                return -1;
        }
