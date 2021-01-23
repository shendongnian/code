    public class Class3
    {
        public enum Type { Order, Inventory }
        private interface IProvidesGetData{ object getData(); }
        private class Class1 : IProvidesGetData { /* ... */ }
        private class Class2 : IProvidesGetData { /* ... */ }
        //...
    }
