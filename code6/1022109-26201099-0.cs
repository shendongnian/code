    namespace context1 {
        using common; // using as #include
        partial class A {
            String s = "contetx1";
        }
    }
    
    namespace context2 {
        using common; // using as #include
        partial class A {
            String a = "blablabla";
            String s = "context2";
        }
    }
