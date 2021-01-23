    public bool CheckStr(string str)
    {
        if (str == "error")
        {
            return false;
        }
        ...
        return true;
    }
    public void Script()
    {
        // ...
        string str = "error";
        if (CheckStr(str) == false)
        {
            return;
        }
        // ...
    }
