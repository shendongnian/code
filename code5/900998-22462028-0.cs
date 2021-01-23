    [TestFixture]
    public class Class1
    {
        [Test]
        public void MyUnitTest()
        {
            var a = GetABunchOfAs(); // returns IEnumerable<A>
            var b = GetABunchOfBs(); // returns IEnumerable<B>
            
            CollectionAssert.AreEqual(a, b.OrderBy(x => x.y));
           
        }
        public List<A> GetABunchOfAs()
        {
            return new List<A>
            {
                new A() {x = 1},
                new A() {x = 2},
                new A() {x = 3},
                new A() {x = 4}
            };
        }
        public List<B> GetABunchOfBs()
        {
            return new List<B>
            {
                new B() {y = "4"},
                new B() {y = "1"},
                new B() {y = "2"},
                new B() {y = "3"},
                
            };
        }
    }
    public class A
    {
        public int x;
        public override bool Equals(object obj)
        {
            return obj.ToString().Equals(x.ToString());
        }
        public override string ToString()
        {
            return x.ToString();
        }
    }
    public class B
    {
        public string y;
        public override string ToString()
        {
            return y;
        }
        public override bool Equals(object obj)
        {
            return obj.ToString().Equals(y);
        }
    }
