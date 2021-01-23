    public class BaseCustomization : CompositeCustomization
    {
        public BaseCustomization()
            : base(
                new BCustomization(),
                new AlternatingCustomization())
        {
        }
    }
