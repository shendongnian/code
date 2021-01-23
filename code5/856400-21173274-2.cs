    public static class ShapeFactory
    {
        private static Dictionary<string, Func<IShape>> _shapes = new Dictionary<string, Func<IShape>>();
        static ShapeFactory()
        {
            // Register some creators:
            _shapes.Add("region", () => return new Region());
            _shapes.Add("area", () => return new Area());
        }
        public static IShape Create(string shape) 
        {
            return _shapes[shape]();
        }
    }
