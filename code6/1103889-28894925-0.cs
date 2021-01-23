    public async void ConnectAsync()
    {
        conn = new ConstantConnection ();
        await conn.Connect ();
    }
