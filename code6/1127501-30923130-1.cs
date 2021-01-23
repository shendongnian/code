    [TestFixture(typeof(Winner))]
    [TestFixture(typeof(Loser))]
    public class CompetitorTests<T> where T : ICompetitor, new()
    {
        static private T CreateSut() {
            return new T();
        }
        [Test]
        public void EverybodyHasPosition() {
            Assert.IsNotNullOrEmpty(CreateSut().GetFinalPosition());
        }
        [TestFixture(typeof(Winner))]
        public class WinnerTests {
            [Test]
            public void TestWon() {
                Assert.AreEqual("Won", CompetitorTests<T>.CreateSut().GetFinalPosition());
            }
        }
        [TestFixture(typeof(Loser))]
        public class LoserTests {
            [Test]
            public void TestLost() {
                Assert.AreEqual("Lost", CompetitorTests<T>.CreateSut().GetFinalPosition());
            }
        }
    }
