    public double[] RedrawArray(double[] ary, int selectedIndex)
    {  
        var lst = new List<double>(ary);
        return lst.RemoveAt(selectedIndex).ToArray();
    }
