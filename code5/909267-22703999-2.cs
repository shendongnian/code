        public class Person
        {
            public int Id { get; protected set; }
            public string Name { get; protected set; }
            public Person(string name = "")
            {
                Id = 8;
                Name = name;
            }
        }
        public class Engineer : Person
        {
            public int Problems { get; private set; }
            public Engineer(string name = "")
                : base(name)
            {
                Problems = 88;
            }
        }
        [TestFixture]
        public class EngineerFixture
        {
            [Test]
            public void Ctor_SetsProperties_AsSpecified()
            {
                var e = new Engineer("bogus");
                Assert.AreEqual("bogus", e.Name);
                Assert.AreEqual(88, e.Problems);
                Assert.AreEqual(8, e.Id);
            }
        }
