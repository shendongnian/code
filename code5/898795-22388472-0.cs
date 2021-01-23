    [TestClass]
    public class DummyTests {
        [TestMethod]
        public void GroupCountByFruitType() {
            // arrange
            var expected = new Dictionary<Fruits, int>() { 
                { Fruits.Grape, 3 }
                , { Fruits.Orange, 4 }
                , { Fruits.Papaya, 0 } 
            };
            Item[] list = new Item[] {
                new Item() { Fruit = Fruits.Orange, Foo = "afc" },
                new Item() { Fruit = Fruits.Orange, Foo = "dsf" },
                new Item() { Fruit = Fruits.Orange, Foo = "gsi" },
                new Item() { Fruit = Fruits.Orange, Foo = "jskl" },
                new Item() { Fruit = Fruits.Grape, Foo = "mno" },
                new Item() { Fruit = Fruits.Grape, Foo = "pqu" },
                new Item() { Fruit = Fruits.Grape, Foo = "tvs" }
            };
            // act
            var actual = Enum.GetValues(typeof(Fruits)).OfType<Fruits>()
                .GroupJoin(list
                    , fruit => fruit
                    , item => item.Fruit
                    , (fruit, group) => new { Key = fruit, Value = group.Count() })
                .ToDictionary(pair => pair.Key, pair => pair.Value);            
            // assert
            actual.ToList()
                .ForEach(item => Assert.AreEqual(expected[item.Key], item.Value));
        }
        private class Item {
            public Fruits Fruit { get; set; }
            public string Foo { get; set; }
        }
        private enum Fruits {
            Grape,
            Orange,
            Papaya
        }
    }
