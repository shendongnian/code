    public class Wrapper<T>
    {
        public T Value { get; set; }
    }
---
    Wrapper<MyClass> wrapper = new Wrapper<MyClass>();
