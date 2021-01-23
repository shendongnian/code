    internal class AutoMoqDataAttribute : AutoDataAttribute
    {
        internal AutoMoqDataAttribute()
            : base(
                new Fixture().Customize(
                    new AutoMoqCustomization()))
        {
        }
    }
    public interface IInterface
    { 
    }
    public class Tests
    {
        [Test, AutoMoqData]
        public void IntroductoryTest(IInterface i)
        {
            Assert.NotNull(i);
        }
    }
