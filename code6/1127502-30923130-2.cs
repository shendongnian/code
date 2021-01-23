    public class CompetitorTestsState<T> where T : ICompetitor, new()  {
        protected T SUT { get; private set; }
        [SetUp]
        public void Setup() {
            SUT = CreateSut();
        }
        
        private T CreateSut() {
            return new T();
        }
    }
    [TestFixture(typeof(Winner))]
    [TestFixture(typeof(Loser))]
    public class CompetitorTests<T> : CompetitorTestsState<T> where T : ICompetitor, new() {
        [Test]
        public void EverybodyHasPosition() {
            Assert.IsNotNullOrEmpty(SUT.GetFinalPosition());
        }
        [TestFixture(typeof(Winner))]
        public class WinnerTests : CompetitorTestsState<T>{
            [Test]
            public void TestWon() {
                Assert.AreEqual("Won", SUT.GetFinalPosition());
            }
        }
        [TestFixture(typeof(Loser))]
        public class LoserTests : CompetitorTestsState<T>{
            [Test]
            public void TestLost() {
                Assert.AreEqual("Lost", SUT.GetFinalPosition());
            }
        }
    }
