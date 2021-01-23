        static int CompareLists(List<int> a, List<int> b)
        {
            var grpA = a.GroupBy(p => p).ToDictionary(k=>k.Key,v=>v.Count());
            var grpB = b.GroupBy(p => p).ToDictionary(k=>k.Key,v=>v.Count());
            for (int i = 10; i >= 0; i--)
            {
                int countA = grpA.ContainsKey(i) ? grpA[i] : 0;
                int countB = grpB.ContainsKey(i) ? grpB[i] : 0;
                int comparison = countA.CompareTo(countB);
                if (comparison != 0)
                    return comparison;
            }
            return 0;
        }
