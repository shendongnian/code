    class MyClass {
      public string Name { get; set; }
    
      [Description("The age description")]
      public int Age { get; set; }
    }
    string ageDescription = GetDescription<MyClass>("age");
    console.log(ageDescription) // OUTPUT: The age description
