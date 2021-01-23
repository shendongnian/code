    public class Salad : Food
      {
        public Salad (){}
    
        public Salad(string propertyName) : base(propertyName)
        {
    
        }
        public override int Calories
        {
          get
          {
            return 200;
          }
        }
    
        public override void Eat()
        {
          Console.WriteLine( "Eat Salad" );
        }
      }
