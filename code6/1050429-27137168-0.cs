    // The original written application had the following class, but then
    // deprecated it (maybe they changed around object, changed interfaces,
    // who knows. It just got deprecated internally.)
    // So, with all the ties in the system, they probably retained the name,
    // but renamed it in the contract.
    [Obsolete]
    [DataContract(Name = "TestClass1")]
    public class TextClass // The class formerly known as TestClass
    {
    }
     
    // This is the refactored TestClass that should be used from here on out.
    // They most likely created a new class with a similar name which lent
    // itself to being plumbed in a modular fashion (but wanted the same name
    // to any service consumers)
    [DataContract(Name = "TestClass")]
    public class TestClassNew
    {
    }
     
    // DTO
    [DataContract]
    public ParentClass
    {
        // Keep the old reference (may still have back-references or
        // functionality that hasn't been migrated). However, they should have
        // also renamed the "Name").
        [DataMember(Name = "TestClass")]
        public TestClass TestClass { get; set; }
        // The new object that now shares the same name.
        [DataMember(Name = "TestClass")]
        public TestClassNew TestClassNew { get; set; }
    }
