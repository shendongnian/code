    public class MyClass : ClassBase 
    {
        // notice "new" to show comiler you know what you doing
        // otherwise you'll get warning (but behavior will be the same)
        new public string Name { get; set; }
    }
