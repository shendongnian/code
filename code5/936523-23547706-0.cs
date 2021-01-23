    private static int CompareEnv(Environment a, Environment b)
        {
            if (String.IsNullOrEmpty(a.name))
            {
                if (String.IsNullOrEmpty(b.name)) return 0;
                else return -1;
            }
            
            if (String.IsNullOrEmpty(b.name)) return 1;
            if (a.name.StartsWith("P"))
            {
                if (b.name.StartsWith("P")) return a.name.CompareTo(b.name);
                else return -1;
            }
            if (b.name.StartsWith("P")) return 1;
            return a.name.CompareTo(b.name);
        }
