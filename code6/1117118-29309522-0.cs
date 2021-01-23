    #region Public Methods
    public Email AddRecipient(IContact Recipient)
    {
        _recipients.Add(Recipient);
        return this;
    }
