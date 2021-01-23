    class Bakery
    {
       private readonly ICakeFactory _cakeFactory;
       public Bakery(ICakeFactory cakeFactory)
       {
           Contract.Requires(cakeFactory != null);
           cakeFactory = _cakeFactory;
       }
       bool BakeStuff()
       {
           var cake = _cakeFactory.CreateCake();
           cake.NameOfCake = "StackOverflow";
           return cake.IsDecorated && cake.IsPacked;
       }
    }
