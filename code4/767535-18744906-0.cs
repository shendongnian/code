    public class MyClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
        protected bool Equals(MyClass other)
        {
            return ID == other.ID;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((MyClass) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return (ID*397) ^ (Name != null ? Name.GetHashCode() : 0);
            }
        }
    }
    public class ExampleTest
    {
        [Fact]
        public void TestForEquality()
        {
            var obj1 = new MyClass { ID = 42, Name = "Rock" };
            var obj2 = new MyClass { ID = 42, Name = "Paper" };
            var obj3 = new MyClass { ID = 42, Name = "Scissors" };
            var obj4 = new MyClass { ID = 42, Name = "Lizard" };
            var list1 = new List<MyClass> {obj1, obj2};
            list1.Should().BeEquivalentTo(obj3, obj4);
        }
    }
