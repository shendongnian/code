    public class ScatterChart : Chart<Point>
    {
        public override IDictionary<string, Point> GetCategoriesData(string serie)
        {
            // Create new Point and set its properties.
            // We know it is a Point because we specified it in the class generic type.
        }
    
        // ...
    }
    
    public class BubbleChart : Chart<Point>
    {
        public override IDictionary<string, Bubble> GetCategoriesData(string serie)
        {
            // Create new Bubble and set its properties.
            // We know it is a Bubble because we specified it in the class generic type.
        }
    
        // ...
    }
