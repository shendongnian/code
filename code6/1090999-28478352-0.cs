    [Column("Foo")]
    public String FooWithWeirdNullValues { get; set; }
    [NotMapped]
    public String Foo {
      get {
        return FooWithWeirdNullValues == "NULL" || FooWithWeirdNullValues == "x"
          ? null : FooWithWeirdNullValues;
      }
      set { FooWithWeirdNullValues = value; }
    }
