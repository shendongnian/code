    class A 
    {
        [Attribute1]
        [AttributeN]
        bool Prop {get;set;}
    
    }
    
    void Main ()
    {
        A a;
        var attrs = typeof(A).GetProperty("Prop").GetCustomAttributes();
    }
