    public class House{
        public class Kitchen{
            //some public properties
            public int numberOfChairs {get; set;}
        }
        public Kitchen TheKitchen { get; set; }
    }
    //Now want to access Kitchen in another class.
    public class Main{
            House newHouse = new House();
            newHouse.TheKitchen = new House.Kitchen();   
            newHouse.TheKitchen.numberOfChairs = 5;
    }
