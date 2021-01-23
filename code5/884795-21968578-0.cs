    public interface IOptionFactory
    {
        MyBaseClass Create(Option option);
    }
    public sealed class OptionFactory : IOptionFactory
    {
        private readonly Dictionary<Option, Func<MyBaseClass>> _optionMapping;
        public OptionFactory()
        {
            Func<MyBaseClass> makeDerivedTwo = () => new DerivedClassTwo();
            _optionMapping = new Dictionary<Option, Func<MyBaseClass>>
            {
                { Option.Option1, () => new DerivedClassOne() },
                { Option.Option2, makeDerivedTwo },
                { Option.Option3, makeDerivedTwo }
            };
        }
        public MyBaseClass Create(Option option)
        {
            return _optionMapping[option]();
        }
    }
