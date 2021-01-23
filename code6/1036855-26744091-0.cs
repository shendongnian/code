    namespace N1.N2
    {
       class A {}
    }
    namespace N3
    {
      using A = N1.N2.A;
      class B: A {}
    }
