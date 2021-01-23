    [NotMapped]
    public MyEnum MyEnum
    {
        get { return (MyEnum) MyActualFKColumnId; }
        set { MyActualFKColumnId=(int)value; }
    }
