    public class House{
    
        public class Kitchen{
            //some public properties
            public int numberOfChairs {get; set;}
        }
    
        public House() {
          kitchen = new Kitchen();
        }
    
        public Kitchen kitchen {get; set;}
    
    }
    
    public class Main{
        House newHouse = new House();
        newHouse.kitchen.numberOfChairs = 5;
    }
