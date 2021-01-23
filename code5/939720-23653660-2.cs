    public void startUpdateChecking()
    {
        UpdateHandler process = new UpdateHandler();
        string Value1 = process.initialize(this);
        ChangeText(Value1);
    }
