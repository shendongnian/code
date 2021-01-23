    [TestClass]
    public class BowlingTests
    {
        [Test]
        public void ThrowNormal_NormalScore()
        {
            var b = new Bowling();
            b.Throw(5);
            b.Throw(6);
    
            Assert.That(b.GetScore(), Is.EqualTo(11));
        }
    
        public void ThrowSpare_SpecialScore()
        {
             var b = new Bowling();
             b.Throw(1);
             b.Throw(11); // = spare
             b.Throw(5);  // score counts for double?
             b.Throw(3);  // No double score
    
             Assert.That(b.GetScore(), Is.EqualTo(1 + 11 + (5 * 2) + 3));
        }
    
        // More tests for all the edge cases (strike, special end of game rules etc)
    }
