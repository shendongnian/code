    internal class UnitTestConventionsAttribute : AutoDataAttribute
    {
        internal UnitTestConventionsAttribute()
            : base(new Fixture().Customize(new AutoMoqCustomization()))
        {
        }
    }
