    public static EmailTemplate CreateDerivedTemplate(Topic topic)
    {
        // You do have to copy/paste this initialize logic here, I'm afraid.
        return (new DerivedEmailTemplate()).Initialize(topic);
    }
    protected override CreateSubject...
