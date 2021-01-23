    using System;
    using System.Linq;
    
    namespace ConceptApplication
    {
        static class Program
        {
            static void Main(string[] args)
            {
                var foobar = new Foobar
                {
                    SomeProperty = Numbers.Five
                };
            }
        }
    
        public class Foobar
        {
            private static Numbers _someProperty;
    
            [NumberRestriction(Allowed = new[] {Numbers.One, Numbers.Two})]
            public Numbers SomeProperty
            {
                get { return _someProperty; }
                set
                {
                    RestrictionValidator.Validate(this, "SomeProperty", value);
    
                    _someProperty = value;
                }
            }
        }
    
        public class NumberRestriction : Attribute
        {
            public Numbers[] Allowed { get; set; }
        }
    
        public static class RestrictionValidator
        {
            public static void Validate<T>(T sender, string propertyName, Numbers number)
            {
                var attrs = sender.GetType().GetProperty(propertyName).GetCustomAttributes(typeof(NumberRestriction), true);
    
                if (attrs.OfType<NumberRestriction>().Any(attr => !(attr).Allowed.Contains(number)))
                    throw new ArgumentOutOfRangeException();
            }
        }
    
        public enum Numbers
        {
            One,
            Two,
            Three,
            Four,
            Five
        }
    }
