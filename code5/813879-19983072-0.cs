     [Test]
        public void Using_String_Join()
        {
            var l = new List<List<string>>
            {
                new List<string> {"John", "Doe", "Tall", "Old"},
                new List<string> {"John", "Doe", "Short", "Old"},
                new List<string> {"Jane", "Doe", "Tall", "Young"},
                new List<string> {"Jane", "Doe", "Short", "Old"}
            };
            var l2 = new List<string> {"John", "Doe", "Short", "Old"};
            Assert.That(l.Count(inner => string.Join(",", inner).Equals(string.Join(",", l2))), Is.EqualTo(1));
        }
        [Test]
        public void Using_SequenceEqual()
        {
            var l = new List<List<string>>
            {
                new List<string> {"John", "Doe", "Tall", "Old"},
                new List<string> {"John", "Doe", "Short", "Old"},
                new List<string> {"Jane", "Doe", "Tall", "Young"},
                new List<string> {"Jane", "Doe", "Short", "Old"}
            };
            var l2 = new List<string> {"John", "Doe", "Short", "Old"};
            Assert.That(l.Count(inner => inner.SequenceEqual(l2)), Is.EqualTo(1));
        }
