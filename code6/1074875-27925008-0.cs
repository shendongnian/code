    public class MyClass
    {
        [Key]//Added this to get rid of the error: 
             //EntityType 'Class1' has no key defined. Define the key for this EntityType.
        public string Key { set; get; }
        public string Something { set; get; } 
    }
