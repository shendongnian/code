    interface E1
    { 
         prop g;
         prop h;
    }
    interface E2
    {
         J j;
    }
    class E : E1, E2
    {
         prop g; prop h; J j;
    }
    interface ICast1
    {
        E1 e;
    }
    interface ICast2
    {
        E2 e;
    }
    class A : ICast1, ICast2
    {
        E1 ICast1.e {get;set;}
        E2 ICast2.e {get;set;}
    }
