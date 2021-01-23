    public class Box {
        // So that it can't be instantiated, or you could make the class abstract
        protected Box()
        {
        }
        public class Properties {
        }
    }
    
    public class Box<E> : Box {
    }
