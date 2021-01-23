     private class ItemBinding
        {
            public string ID { get; set; }
        }
        [TestMethod]
        public void TestMethod1()
        {
            System.Collections.Generic.HashSet<ItemBinding> set = new System.Collections.Generic.HashSet<ItemBinding>();
            ItemBinding item1 = new ItemBinding() { ID = "Jaffa" };
            set.Add(item1);
            Assert.IsTrue(set.Count == 1);
            set.Remove(item1);
            Assert.IsTrue(set.Count == 0);
            ItemBinding item2 = new ItemBinding() { ID = "Moon" };
            set.Add(item2);
            ItemBinding item3 = new ItemBinding() { ID = "Moon" };
            Assert.IsTrue(item2.GetHashCode() != item3.GetHashCode());
            Assert.IsTrue(set.Remove(item3) == false);
            Assert.IsTrue(set.Count == 1);
        }
