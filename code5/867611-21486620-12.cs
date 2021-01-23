    public class ClassBase
    {
        partial void CallMethod();
        public string Name {get {CallMethod(); return "";}}
    }
    public class DerivedBase
    {
        void CallMethod() { /* do something here */ }
    }
