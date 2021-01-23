    [TestMethod]
    public void TestAddition(){
    
    testAddition(3,1,2);
    testAddition(4,2,2);
    testAddition(5,3,2);
    
    }
    
    private void testAddition(int expected, int x,int y){
    
    var actual = x + y;
    
    Assert.AreEqual(expected,actual);
    }
