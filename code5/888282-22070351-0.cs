    // Assuming Type11 and Type21 have the same Foo property
    // Add the following inside Type11
    public static explicit operator Type21(Type11 t)
    {
        return new Type21 { Foo = t.Foo };
    }
