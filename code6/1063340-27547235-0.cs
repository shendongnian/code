    public class A
    {
        public virtual void DoSomething(string a)
        {
          // perform something
        }
        public virtual void DoSomething(string a, string b)
        {
          // perform something
        }
    }
    public class B : A
    {
        public override void DoSomething(string a, string b)
        {
          // perform something slightly different using both strings
        }
    }
