    private List<Point> sanitize(List<Point> crossPoints) {
        var workset = new List<Point>(crosspoints);
        SortedSet<int> indexesToDelete = new SortedSet<int>();
    
        for (int i = 0; i < workset.Count() - 1; i++) {
            if (Math.Abs(workset[i + 1].X - workset[i].X) <= 5 &&
                Math.Abs(workset[i + 1].Y - workset[i].Y) <= 5) {
                indexesToDelete.Add(i);
                indexesToDelete.Add(i + 1);
            }
        }
    
        foreach (int i in indexesToDelete.Reverse()) {
            workset.RemoveAt(i);
        }
    
        return workset;
    }
