    public class TestConventionsAttribute : AutoDataAttribute
    {
        public TestConventionsAttribute()
            : base(new Fixture().Customize(new AutoMoqCustomization()))
        {
        }
    }
