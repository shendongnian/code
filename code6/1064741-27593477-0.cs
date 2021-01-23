    public class SomeClass
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class SomeClassCollection : KeyedCollection<string,SomeClass>
    {
        protected override string GetKeyForItem(SomeClass item)
        {
            return item.Name;
        }
    }
    [TestClass]
    public class KeyedCollectionTests
    {
        [TestMethod]
        public void Test()
        {
            var items = new SomeClassCollection
                        {
                            new SomeClass{Name = "Name 1", Value = "Value 1"},
                            new SomeClass{Name = "Name 2", Value = "Value 2"}
                        };
            items["Name 1"].Value.Should().Be("Value 1");
            items[1].Value.Should().Be("Value 2");
        }
    }
