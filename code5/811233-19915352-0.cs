    public class FoodItem
    {
        public const in MaxNumberOfPeople = 4;
        // no extra logic for this field
        public string Name {get;set;} 
        // this one have backing field and some special logic for set:
        private int numberServed;
        public int NumberServed {
           get { return numberServed;}
           set 
           {
               /* some special code here if needed*/
               numberServed = value > MaxNumberOfPeople ? 0 : value;
           } 
        }
    }
  
