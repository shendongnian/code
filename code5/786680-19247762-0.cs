    public abstract class Beverage<T> where T : Beverage<T>
    {
        public abstract T Blend(T drink1, T drink2);
    }
    
    public class Tea : Beverage<Tea>
    {
        public override Tea Blend(Tea drink1, Tea drink2)
        { 
            // Blend tea here.
        }
    }
    public class Coffee : Beverage<Coffee>
    {
        public override Coffee Blend(Coffee drink1, Coffee drink2)
        { 
            // Blend coffee here.  Although coffee is nasty, so
            // why you'd want to is beyond me.
        }
    }
