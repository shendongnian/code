    public class Object2 
    {
    
        public static implicit Object2(Object1 ojbect1)
        {
            return new Object2{
                field1 = object1.field1,
                field2 = object1.field2
            }
        }
    
    }
    Object2 object2 = object1;
