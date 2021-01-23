    public class Fruit
    {
        public static explicit operator bool(Fruit D)
        {
             // handle null references
             return D.ToBoolean();
        }
        protected virtual bool ToBoolean()
        {
             return false;
        }
    }
