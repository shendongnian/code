    public interface IShape {
        void AddShapeToPath(GraphicsPath path);
    }
    
    public class Rectangle: IShape
    {
        // properties removed for readability
        public void AddShapeToPath(GraphicsPath path)
        {
            path.AddRectangle(new Rectangle(Location.X, Location.Y, Size.Width, Size.Height));
        }
    }
    protected override GraphicsPath Build(IShape inShape )
    {
        var newPath = new GraphicsPath();
        inShape.AddShapeToPath(newPath);
        return newPath;
    }
