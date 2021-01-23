    public class MyClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class MyClassComparer : IEqualityComparer<MyClass>
    {
        public bool Equals(MyClass x, MyClass y)
        {
            return x.ID == y.ID;
        }
        public int GetHashCode(MyClass obj)
        {
            return obj.ID.GetHashCode();
        }
    }
    public class ExampleTest
    {
        [Fact]
        public void TestForEquality()
        {
            var obj1 = new MyClass { ID = 42, Name = "Brad" };
            var obj2 = new MyClass { ID = 42, Name = "Joe" };
            Assert.Equal(new[] { obj1 }, new[] { obj2 }, new MyClassComparer());
        }
    }
