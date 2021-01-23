    private EmailTemplate()
    {
       // private constructor to force the factory method to create the object
    }
    
    public static EmailTemplate CreateBaseTemplate(Topic topic)
    {
        return (new BaseEmailTemplate()).Initialize(topic);
    }
    protected EmailTemplate Initialize(Topic topic)
    {
       // ...call virtual functions here
       return this;
    }
