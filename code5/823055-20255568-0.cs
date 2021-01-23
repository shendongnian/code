    var testObject = new TestObject();
    testObject.Property1 = "Value1";
    testObject.Property2 = 44;
    testObject.TestObject2 = new TestObject2();
    testObject.TestObject2.Property1 = "NestedValue1";
    var scriptEngine = new ScriptEngine();
    scriptEngine.AddReference(typeof(TestObject).Assembly);
    var session = scriptEngine.CreateSession(new HostObject() { TestObject = testObject });
    session.Execute("TestObject.Property1 = \"Value2\"");
    session.Execute("TestObject.TestObject2.Property1 = \"Sub Property String\"");
    var test1 = testObject.Property1 == "Value2"; // true
    var test2 = testObject.TestObject2.Property1 == "Sub Property String"; // true
