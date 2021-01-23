    abstract class BaseDoingThings
    {
        abstract void Do();
    }
    class Something : BaseDoingThings
    {
        override Do() { ... }
    }
    class SomethingElse : BaseDoingThings
    {
        override Do() { ... }
    }
