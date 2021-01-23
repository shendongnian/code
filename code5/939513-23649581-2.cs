    [TestMethod]
    public void CheckInterfaceInheritenceTest()
    {
        foreach (Type typeToCheck in Assembly.GetAssembly(typeof(MyClass)).GetTypes())
        {
            MyInterfaceCheckAttribute myAtt = typeToCheck.GetCustomAttribute(typeof(MyInterfaceCheckAttribute), true) as MyInterfaceCheckAttribute;
            if (myAtt != null)
            {
                Type[] interfaces = typeToCheck.GetInterfaces();
                if (!interfaces.Contains(myAtt.TypeThatShouldBeInherited))
                {
                    Assert.Fail("The type " + typeToCheck.Name + " should inherit the interface " + myAtt.TypeThatShouldBeInherited.Name);
                }
            }
        }
    }
