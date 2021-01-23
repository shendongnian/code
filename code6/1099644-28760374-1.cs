    List<string> lst1 = new List<string> { "A", "B", "A" };
    List<string> lst2 = new List<string> { "AA", "BB", "AC" };
    HashSet<string> seen = new HashSet<string>();
    for (int i = 0; i < lst1.Count; i++) {
        if (!seen.Add(lst1[i])) {
            lst1.RemoveAt(i);
            lst2.RemoveAt(i);
            i--;
        }
    }
