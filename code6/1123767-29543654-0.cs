    public struct NamesConstants
    { 
        public const string SomeConstant = "Hello";
        public const string SomeOtherConstant = "World";
    }
    public class SomethingWithAReallyReallyAnnoyinglyLongName{
        public struct Names
        {
            public const string SomeConstant = NamesConstants.SomeConstant;
            public const string SomeOtherConstant = NamesConstants.SomeOtherConstant;
        }
    }
