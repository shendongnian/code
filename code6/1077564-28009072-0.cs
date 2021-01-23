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
            List<IDebugPrints> characters = null;
            var sl = new StoreList(characters);
        }
    }
