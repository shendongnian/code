    public enum BarTypeEnum
    {
        [FooConverter] // no properties mapped
        TypeA,
        [FooConverter(Parameters="Prop1")] // map Prop1 from Foo to Bar
        TypeB,
        TypeC, // no instance
        [FooConverter(Parameters="Prop1, Prop2")] // map Prop1/2 from Foo to Bar
        TypeD, 
        TypeE // no instance
    }
    public List<Bar> Convert(Foo foo)
    {
        return Enum.GetValues(typeof(BarTypeEnum))
            .Cast<BarTypeEnum>()
            .Select(barType => barType.GetInstance(foo))
            .Where(newBar => newBar != null)
            .ToList();
    }
