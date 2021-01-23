        [Test()]
        [TestCase("a","a","a")]
        [TestCase("a", "b", "a")]
        public void  Dummy(string a, string a1, string a2)
        {
            Assert.That(a, Is.EqualTo(a1).And.EqualTo(a2));
        }
