     public class Base
        {
            
        }
        public class Rabbit : Base
        {
        }
        public abstract class OO
        {
            public abstract ICollection<T> Test<T>() where T : Base;
        }
        public class LOL : OO
        {
            public override ICollection<T> Test<T>()
            {
                return new Collection<T>();
            }
        }
