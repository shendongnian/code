    public class CoordinateSystem : Panel
    {
        // This element will display the actual coordinate system
        // It must be added to the collection of InternalChildren
        private Path _coordinateSystemPath;
        // This method is used to determine how much space the children want to have
        protected override Size MeasureOverride(Size availableSize)
        {
            Size infiniteSize = new Size(double.PositiveInfinity, double.PositiveInfinity);
            Size desiredSize = new Size();
            // Measure how many space the items you want to display need
            foreach (var child in InternalChildren)
            {
                child.Measure(infiniteSize);
                // Check at which position this child wants to be and
                // calculate the desired size of the coordinate system
            }
            return desiredSize;
        }
        // this method will arrange the path for the coordinate system as well as
        // all the children that will be displayed
        protected override Size ArrangeOverride(Size finalSize)
        {
            foreach (var child in InternalChildren)
            {
                if (child == _coordinateSystemPath)
                {
                    // Update the PathGeometry of this path according to provided finalSize here
                    continue;
                }
                child.Arrange(child.DesiredSize);
            }
        }
    }
