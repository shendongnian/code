    ControlB = genericControl(parentWindow,     
        "ControlType","Button","ControlName","Send");
    TestOne(ControlB);
    TestOne(ControlC);
    public void TestOne(UITestControl control, string Value)
    { 
        //do stuff
        Mouse.Click(control);
        Assert.AreEqual(Value, control.GetProperty("InnerText"));
    }
