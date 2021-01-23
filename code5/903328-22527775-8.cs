    public IOutput GetResponse(IInput input)
    {
        if (input is AInput || input is BInput)
        {
            return new XOutput();
        }
        if (input is CInput || input is DInput)
        {
            return new YOutput();
        }
        return new ErrorOutput();
    }
