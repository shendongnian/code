    partial public class ClassBase
    {
        partial void CallMethod();
        public string Name {get {CallMethod(); return "";}}
    }
    // in generated portion of "ClassBase"
    partial public class ClassBase
    {
        partial void CallMethod() { /* do something here */ }
    }
