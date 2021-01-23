        public static Dog Find(List<Dog> AllDogs, string Id)
        {
            int p = 0;
            int n = AllDogs.Count;
            while (true)
            {
                int m = (n + p) / 2;
                Dog d = AllDogs[m];
                int r = string.Compare(Id, d.Id);
                if (r == 0)
                    return d;
                if (m == p)
                    return null;
                if (r < 0)
                    n = m;
                if (r > 0)
                    p = m;
            }
        }
