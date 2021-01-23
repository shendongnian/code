    public class BoxProperties
    {
    }
    interface IBox
    {
    }
    public class Box<E> : IBox where E : BoxProperties
    {
    }
    public class BlueBox : Box<BlueBox.BlueProperties>
    {
        public class BlueProperties : BoxProperties
        {
        }
    }
    public class Properties
    {
    }
    public class RedBox : Box<RedBox.RedProperties>
    {
        public class RedProperties : BoxProperties
        {
        }
    }
