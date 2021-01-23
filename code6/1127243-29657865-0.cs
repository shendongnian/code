     public void TestMethod()
        {
           var ctr = new MyApiController();
           string name = ctr.GetName();
           Assert.IsTrue(name == "xpto");
        }
