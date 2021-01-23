    [TestMethod]
    public void Testing()
    {
        byte b = 48;
        var item = My_Class.CharactersMapper
                           .Where(d => d.Key.Key_2 == b)
                           .FirstOrDefault();
        
        Assert.IsNotNull(item, "not found");
    
        char ch = item.Value;
        Assert.AreEqual('a', ch, "wrong value found");
    }
