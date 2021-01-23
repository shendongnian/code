    public void OnMouseDrag()
    {
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint)+offset;
        ...
        ObjectPosition = curPosition;
    }
    void OnMouseUp()
    {
        Debug.Log(string.Concat("GameObject is now at ", ObjectPosition));
    }
