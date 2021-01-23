    public bool UserNameEditable
    {
        get{ return !TxtUserName.ReadOnly; }
        set{ TxtUserName.ReadOnly = !value; }
    }
