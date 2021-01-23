    using System.Collections.Generic;
    using NUnit.Framework;
    
    namespace ClassLibrary1
    {
        [TestFixture]
        public class Stack1
        {
            [Test]
            public void TestConfigItems()
            {
                var currentConfig = new Config();
    
                currentConfig.item1.name = "A";
                currentConfig.item2.name = "B";
    
                for (int i = 0; i < currentConfig.listOfItems.Count; i++)
                {
                    Assert.AreNotEqual("Not Set", currentConfig.listOfItems[i].name);
                    Assert.AreEqual(i == 0 ? "A" : "B", currentConfig.listOfItems[i].name);
                }
            }
    
            public class Config
            {
                public List<Item> listOfItems = new List<Item>();
                public Item item1 = new Item();
                public Item item2 = new Item();
    
                public Config()
                {
                    listOfItems.Add(item1);
                    listOfItems.Add(item2);
                }
            }
    
            public class Item
            { 
                public string name;
    
                public Item()
                { 
                    name = "Not Set";
                }
            }
        }
    }
