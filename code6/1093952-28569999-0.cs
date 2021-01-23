    Public abstract class A<TTest>
        Where TTest : ITest1
     {
        Public abstract TTest TestProperty {get; set;}
     }
    
     Public class B : A<ITest2>
     {
     ....
     }
