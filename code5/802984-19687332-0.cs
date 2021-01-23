        class Base
        {
            abstract public void Print();
        }
        class Derived: Base
        {
             public override void Print()
             {}
        }
        Main()
        {
             Base base = new Derived();
             //its possible
             base.Print();
        }
