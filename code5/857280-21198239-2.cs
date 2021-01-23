    public abstract class Drawable
    {
        public double x { get; set; }
        public double y { get; set; }
        public abstract object GetDrawable();
    }
    public class Beacon : Drawable
    {
        public Beacon(string id, double x, double y)
        {
            //this.id = id;
            this.x = x; 
            this.y = y;
        }
        public override object GetDrawable()
        {
            // ...
        }
    }
