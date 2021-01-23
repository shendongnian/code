    [Test]
    public void ConfirmAspectAttached()
    {
       var serviceType = typeof( MyViewModel );
       var member = serviceType.GetMembers().Where( member.Name == "DoSmth" ).FirstOrDefault(); // probably a better way of doing this
       Assert.IsNotNull( member );
       Assert.IsTrue( member.GetCustomAttributes(true).Any(attrib => attrib.GetType() == typeof(MyMethodAspectAttribute )));
    }
