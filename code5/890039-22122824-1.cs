    public class MyClass
    {
        private IShape Bounds;
        protected TShape GetBounds<TShape>() where TShape : IShape
        {
            return (TShape)Bounds; //Note this will throw an exception if the wrong shape is specified
        }
        //Rest of class
    }
