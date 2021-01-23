    [TestMethod]     
    public void FailIfEnumIsNotDefined_Check_That_The_Value_Is_Not_Enum()
    {
        // PREPARE
        try
        {
           // EXECUTE
           Assert.Fail()
        }
        catch(Exception exception)
        {        
            // ASSERT EXCEPTION DETAILS
        }
    }
