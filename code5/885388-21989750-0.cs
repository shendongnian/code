    public interface ISomething {
        void SomeMethod();
    }
    public SpecificClass1Wrapper : SpecificClass1, ISomething {
        void SomeMethod() { SomeMethod1(); }
    }
