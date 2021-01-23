    pubic abstract class BaseValidation {
        public const ContainNumbers int = 1;
        public const ContainIlligalCharacters = 2;
        public const ContainEmptyString = 3;
        public const PassedValidation = 4
    }
    
    public class FirstName: BaseValidation {
        public const SomethingDifferent = 5;
    }
    
    public class LastName: BaseValidation {
        public const SomethingMoreDifferent = 5;
        public const SomethingEvenMoreDifferent = 6;
    }
