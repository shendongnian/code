    public int[] SelectedFruits
    {
        get
        {
            return Fruits != null && Fruits.Count > 0
            ? Fruits.Where(f => f.Selected == true).Select(f => f.Id).ToArray()
            : new int[0];
        }
        set { }
    }
