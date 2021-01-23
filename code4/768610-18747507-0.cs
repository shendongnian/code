    interface IBox<out E> where E : BoxProperties
    {
    }
    public class Box<E> : IBox<E> where E : BoxProperties
    {
    }
    public class BoxProperties
    {
    }
    public class BlueBox : Box<BlueBox.BlueProperties>
    {
        public class BlueProperties : BoxProperties
        {
        }
    }
    public class RedBox : Box<RedBox.RedProperties>
    {
        public class RedProperties : BoxProperties
        {
        }
    }
