            Hashtable hm = new Hashtable();
            int[] a = new int[] { 1, 2, 3, 4, 5 };
            int[] b = new int[] { 2, 4, 6, 7, 8 };
            int[] c = new int[] { 3, 4, 5, 6, 9 };            
            foreach (var iA in a)
            {
                foreach (var iB in b)
                {
                    if (iA == iB && !hm.ContainsKey(iA))
                    {
                        hm.Add(iA, iA);
                    }
                }
            }
            foreach (var iC in c)
            {
                if (hm.ContainsKey(iC))
                {
                    Console.WriteLine(iC);
                    hm.Remove(iC);
                }
            }
