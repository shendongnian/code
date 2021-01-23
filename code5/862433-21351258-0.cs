    public abstract class Shape
    {
        public String toString()
        {
            return InternalToString();
        }
    
        protected abstract string InternalToString();
    }
    
    public class Rectangle : Shape
    {
        public Double width { get; set; }
        public Double height { get; set; }
    
        protected override string InternalToString()
        {
            return width.ToString() + ", " + height.ToString();
        }
    }
