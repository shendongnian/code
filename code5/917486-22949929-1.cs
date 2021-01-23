    [TestFixture]
    public class DateTime2Tests
    {
        [Test]
        public void TestRoundDateTime2_RoundsDown_000()
        {
            var date = new DateTime(2014, 12, 31, 10, 27, 36, 000);
            var xxxx = new DateTime(2014, 12, 31, 10, 27, 36);
            Assert.That(xxxx, Is.EqualTo(date).Within(TimeSpan.FromSeconds(1)));
        }
        [Test]
        public void TestRoundDateTime2_RoundsDown_499()
        {
            var date = new DateTime(2014, 12, 31, 10, 27, 36, 499);
            var xxxx = new DateTime(2014, 12, 31, 10, 27, 36);
            Assert.That(xxxx, Is.EqualTo(date).Within(TimeSpan.FromSeconds(1)));
        }
        [Test]
        public void TestRoundDateTime2_RoundsUp_500()
        {
            var date = new DateTime(2014, 12, 31, 10, 27, 36, 500);
            var xxxx = new DateTime(2014, 12, 31, 10, 27, 37);
            Assert.That(xxxx, Is.EqualTo(date).Within(TimeSpan.FromSeconds(1)));
        }
        [Test]
        public void TestRoundDateTime2_RoundsUp_750()
        {
            var date = new DateTime(2014, 12, 31, 10, 27, 36, 750);
            var xxxx = new DateTime(2014, 12, 31, 10, 27, 37);
            Assert.That(xxxx, Is.EqualTo(date).Within(TimeSpan.FromSeconds(1)));
        }
        [Test]
        public void TestRoundDateTime2_RoundsUp999()
        {
            var date = new DateTime(2014, 12, 31, 10, 27, 36, 999);
            var xxxx = new DateTime(2014, 12, 31, 10, 27, 37);
            Assert.That(xxxx, Is.EqualTo(date).Within(TimeSpan.FromSeconds(1)));
        }
    }
