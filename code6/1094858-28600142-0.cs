    interface I { bool Visible { get; set; } }
    class A { }
    class B : I { public bool Visible { get; set; } }
    class C : B { }
    class D : C { }
