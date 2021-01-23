    public interface IDoSomething {
        void DoThis(int parameter);
    }
    
    public static class DoSomethingDefaults {
        public static void DoThis(this IDoSomething x) {
            x.DoSomething(123); //default value
        }
    }
    
    ///
    new ClassThatImplementsDoSomething().DoThis();
    new ClassThatImplementsDoSomething().DoThis(456);
