    public class Subclass : Baseclass
    {
        public Subclass()
            : base((new Func<string>(() =>
                                     {
                                         const string returnstring = "a";
                                         // Do Something
                                         return returnstring;
                                     })()))
        {
        }
    }
