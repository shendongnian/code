    // using System.Diagnostics.Contracts;
    void Foo(Type type)
    {
        Contract.Requires(typeof(Attribute).IsAssignableFrom(type));
        …
    }
