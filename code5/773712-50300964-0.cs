    public static DerivedEmailTemplate CreateDerivedTemplate(Topic topic)
    {
        // You do have to copy/paste this initialize logic here, I'm afraid.
        var result = new DerivedEmailTemplate();
        result.Initialize(topic);
        return result;
    }
