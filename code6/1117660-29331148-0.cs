    private string[] ToStringArray()
    {
        if (this.Count == 0)
            return null;
        string[] items = new string[this.Count];
        for (int i = 0; i < this.Count; i++)
        {
            items[i] = this[i].ToString();
        }
        return items;
    }
