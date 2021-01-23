    public void ApplyNestingLevel(Foo f)
    {
        ApplyNestingLevel(f, 0);
    }
    public void ApplyNestingLevel(Foo f, int level)
    {
        if(f == null) { return; }
        f.Level = level
        if(f.Childs != null) {
            foreach(Foo child in f.Childs)
            {
                ApplyNestingLevel(child, level + 1);
            }
        }
        if(f.BarObj != null && f.BarObj.Childs != null) {
            foreach(Foo child in f.BarObj.Childs)
            {
                ApplyNestingLevel(child, level + 1);
            }
        }
    }
