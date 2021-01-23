    public class House{
        public Kitchen KitchenProp { get; set; }
        public class Kitchen{
                //some public properties
                public int numberOfChairs {get; set;}
            }
        }
    
    
        //Now want to access Kitchen in another class.
        public class Main{
                House newHouse = new House();
                newHouse.KitchenProp = new Kitchen();
                newHouse.KitchenProp.numberOfChairs = 5;
        }
