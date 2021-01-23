    using System;
    namespace FOOBAR
    {
    class Program
    {
        static void Main(string[] args)
        {
            Foo<string> stringFoo = new Foo<string>("this");
            stringFoo.Value = "that";
            Foo<float> floatFoo = new Foo<float>(2f);
            floatFoo.SetFloat(4f);//same as  
        }
    }
    class Foo<T>
    { 
        T value;
        public T Value { get { return value; } set { this.value = value; } }
        public Foo(T val)
        {
            value = val;
        }
    }
    public static class FooHelper //this is a class we don't use by itself
    {
        //this is an extension method we can use directly from the extended type (Foo<Float>)
        public static void SetFloat(this Foo<float> floatFoo, float value)
        {
            floatFoo.Value = value;//this is redunant unless we do something more complicated
        }
    }
    }
