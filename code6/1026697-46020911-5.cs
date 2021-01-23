    class MyClass {
      public string Name { get; set; }
    
      [Description("The age description")]
      public int Age { get; set; }
    }
    string ageDescription = GetDescription<MyClass>("Age");
    console.log(ageDescription) // OUTPUT: The age description
