    public unsafe int Execute()
    {
        
        ......
        flag = 0;
        if (this.connection != null)
        {
            goto Label_0015;
        }
        throw new InvalidOperationException(Resources.ConnectionNotSet);
    Label_0015:
        if (this.query == null)
        {
            goto Label_002A;
        }
        if (this.query.Length != null)
        {
            goto Label_002C;
        }
    Label_002A:
        return 0;
    Label_002C:
        if (this.connection.State == 1)
        {
            goto Label_0047;
        }
        flag = 1;
        this.connection.Open();
        ....
