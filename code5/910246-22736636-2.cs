    public class Bat
    {
        public int A { get; set; }
        public void SetValueA()
        {
            A = 20;
        }
    } 
    public class Nah
    {
       public int B { get; set; }
       public void SetValueB()
       {
           Bat bat = new Bat();
           bat.SetValueA();
           B = bat.A;
       }
    }
