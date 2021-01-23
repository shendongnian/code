    public int GetHashCode(CanvasAccount obj)
    {
        int hash = 23;
        hash = hash * 31 + obj.UserName.ToLower().GetHashCode();
        hash = hash * 31 + obj.Password.GetHashCode();
        return hash;
    }
