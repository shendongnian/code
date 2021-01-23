    public class MyInterfaceCheckAttribute : Attribute
    {
        public MyInterfaceCheckAttribute(Type typeThatShouldAlsoBeInherited)
        {
            if (!typeThatShouldAlsoBeInherited.IsInterface)
            {
                throw new ArgumentException("Incorrect type being used with MyInterfaceCheckAttribute.");
            }
            TypeThatShouldBeInherited = typeThatShouldAlsoBeInherited;
        }
        public Type TypeThatShouldBeInherited { get; private set; }
    }
