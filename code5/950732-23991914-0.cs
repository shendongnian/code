    CountList.Sort((t1, t2) => {
            int c = t1.Item1.CompareTo(t2.Item1);
            if (c != 0) return c;
            c = t1.Item2.CompareTo(t2.Item2);
            return -c;
        }
    );
