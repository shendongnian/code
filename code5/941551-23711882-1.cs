    public void OnClick(Vector2 pos)
    {
        OnClickCore(pos);
        OnClickMethod(pos);
    }
    
    public abstract void OnClickCore(Vector2 pos);
