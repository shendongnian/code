        interface IFoo<T>
        {
            T GetOtherThis();
        }
        public class NotAString : Foo<string>
        {
            string GetOtherThis() { ... }
        }
