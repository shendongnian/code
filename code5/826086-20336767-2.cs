    public class Ammo
    {
        public int Value {get; set;}
        public bool Maxed 
        {
           get
           {
             return Value > 100;
           }
        }
    }
