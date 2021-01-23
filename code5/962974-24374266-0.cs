    class Program : baseclass, interfc
    {
        interfc onj2 = new Program();//is it creating object object of interfc?
        baseclass b = new baseclass();
        baseclass b2 = new Program();  // why its showing error here
        public void sub()
        {
            throw new NotImplementedException();
        }
    }
    public abstract class abstrct
    {
        public void  program2()
        {
        }
        public abstract void add();
    }
    interface interfc
    {
        void sub();
    }
    class baseclass
    {
      public void div()
      {
          Console.WriteLine("base class method");
      }
    }
