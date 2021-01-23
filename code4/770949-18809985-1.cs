    public double[] RedrawArray(double[] ary, int selectedIndex)
    {  
        var lst = new List<double>(ary);
        lst.RemoveAt(selectedIndex);
        return lst.ToArray();
    }
