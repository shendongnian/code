    // ...
    using YourApp.Extensions.GuidExtensions;
    // ...
    
    class SomeClass {
        Guid SomeMethodWithFirstLetter() {
            return Guid.NewGuid().FirstLetter();
        }
        Guid SomeMethodWithOnlyLetters() {
            return Guid.NewGuid().OnlyLetters();
        }
    }
