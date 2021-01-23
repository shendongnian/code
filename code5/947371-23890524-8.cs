    [TestClass]
    public class Test
    {
       private List<int> list;
       public Test()
       {
          list = new List<int>();
       }
       [TestMethod]
       public void can_add_to_list()
       {
          list.Add(10);
          Assert.areEqual(1, list.Count);
       }
       [TestMethod]
       public void can_add_two_to_list()
       {
          list.Add(10);
          list.Add(20);
          Assert.areEqual(2, list.Count);
       }
    }
