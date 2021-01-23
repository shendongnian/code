    public class MyObject {
        public string Item;
        public int Position;
    }
    List<MyObject> lst1 = new List<MyObject> { 
        new MyObject { Item = "A", Position = 1 },
        new MyObject { Item = "B", Position = 2 },
        new MyObject { Item = "A", Position = 3 },
    };
    List<MyObject> lst2 = new List<MyObject> { 
        new MyObject { Item = "AA", Position = 1 },
        new MyObject { Item = "BB", Position = 2 },
        new MyObject { Item = "AC", Position = 3 },
    };
    HashSet<string> seen = new HashSet<string>();
    HashSet<int> toBeDeleted = new HashSet<int>();
    for (int i = 0; i < lst1.Count; i++) {
        if (!seen.Add(lst1[i].Item)) {
            toBeDeleted.Add(lst1[i].Position);
            lst1.RemoveAt(i);
            i--;
        }
    }
    if (toBeDeleted.Count > 0) {
        for (int i = 0; i < lst2.Count; i++) {
            if (toBeDeleted.Contains(lst2[i].Position)) {
                lst2.RemoveAt(i);
                i--;
            }
        }
        // or equivalent and shorter, without the for cycle
        //lst2.RemoveAll(x => toBeDeleted.Contains(x.Position));
    }
