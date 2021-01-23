    using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
    using System.Collections.Generic;
    
    public interface IDebugPrints
    {
    
    }
    
    public class Character : IDebugPrints
    {
    
    }
    
    public class StoreList
    {
        private List<IDebugPrints> internalList;
    
        public StoreList(List<IDebugPrints> inList)
        {
            internalList = inList;
        }
    }
    
    [TestClass]
    public class Test1
    {
        [TestMethod]
        public void MyTest()
        {
            var characters = new List<IDebugPrints>();
            characters.Add(new Character());
            var sl = new StoreList(characters);
        }
    }
