    [Column("MyActualFKColumnId", TypeName = "int")]
    public MyEnum MyEnum { get; set; }
    // NB : Foreign Key refers to the C# Property, not the DB Field
    [ForeignKey("MyEnum")]
    public MyEntityReferencedByEnum MyEntityReferencedByEnum { get; set; }
