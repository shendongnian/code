    private bool OperatorProcess(ref Message MessageData, string SendInterface)
    {
        parse(message);
        validate(message);
        if(!TEST)  Transfer(message);
    }
