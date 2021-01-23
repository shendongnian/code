       [TestMethod]
        public void NoIntegers()
        {
            Mock<IBar> mockBar = new Mock<IBar>(MockBehavior.Strict);
            Mock<IEnumerable<int>> mockIntegers = new Mock<IEnumerable<int>>(MockBehavior.Strict);
            Mock<IEnumerator<int>> mockEnumerator = new Mock<IEnumerator<int>>(MockBehavior.Strict);
            mockBar
                .SetupGet(x => x.Integers)
                .Returns(mockIntegers.Object);
            mockIntegers
                .Setup(x => x.GetEnumerator())
                .Returns(mockEnumerator.Object);
            mockEnumerator.Setup(x => x.MoveNext()).Returns(false);
            mockEnumerator.Setup(x => x.Dispose());
            Assert.IsFalse(new Foo(mockBar.Object).AreThereIntegers());
        }
        public interface IBar
        {
            IEnumerable<int> Integers { get; }
        }
        public class Foo
        {
            private IBar _bar;
            public Foo(IBar bar)
            {
                _bar = bar;
            }
            public bool AreThereIntegers()
            {
                return _bar.Integers.Any();
            }
        }
