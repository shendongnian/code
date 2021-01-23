    private string message;
    public string Message {
        get { return message; }
        set
        {
            if (message != null)
            {
                throw new ReadOnlyPropertyException("Class1.Message can not be changed once it is set.");
            }
            message = value;
        }
    }
