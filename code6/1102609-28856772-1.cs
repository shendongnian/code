    public bool Paint(IList<IPaintable> paintables, int index, Color color)
    {
        if (index < paintables.Count)
        {
            paintables[index].Paint(color);
            return true;
        }
        return false;
    }
