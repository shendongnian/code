    public class Class3
    {
        public enum Type { Order, Inventory }
        private interface ProvidesGetData{ object getData(); }
        private class Class1 implements ProvidesGetData { /* ... */ }
        private class Class2 implements ProvidesGetData { /* ... */ }
        //...
    }
