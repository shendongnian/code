    [TestMethod]
    public void CheckInterfaceInheritenceTest()
    {
        Dictionary<Type, MyInterfaceCheckAttribute> typesToCheck = new Dictionary<Type, MyInterfaceCheckAttribute>();
        foreach (Type typeToCheck in Assembly.GetExecutingAssembly().GetTypes())
        {
            MyInterfaceCheckAttribute myAtt = typeToCheck.GetCustomAttribute(typeof(MyInterfaceCheckAttribute), true) as MyInterfaceCheckAttribute;
            if (myAtt != null)
            {
                typesToCheck.Add(typeToCheck, myAtt);
            }
        }
        foreach (Type typeToCheck in Assembly.GetExecutingAssembly().GetTypes())
        {
            Type[] interfaces = typeToCheck.GetInterfaces();
            foreach (KeyValuePair<Type, MyInterfaceCheckAttribute> kvp in typesToCheck)
            {
                if (interfaces.Contains(kvp.Key) && !interfaces.Contains(kvp.Value.TypeThatShouldBeInherited))
                {
                    Assert.Fail("The type " + typeToCheck.Name + " should inherit the interface " + kvp.Value.TypeThatShouldBeInherited.Name);
                }
            }
        }
    }
