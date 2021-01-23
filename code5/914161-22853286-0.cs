    public class FixedBoundary
    {
        private Polygon boundary;
        private bool isConvex;
        
        public FixedBoundary(Polygon boundary)
        {
            // deep clone so we don't have to worry about the boundary being modified later.
            this.boundary = boundary.Clone(); 
            this.isConvex = this.boundary.IsConvex();
        }
        
        public bool Contains(Polygon p)
        {
            if (isConvex)
            {
                // efficient convex logic here
            }
            else   
            {
                return this.boundary.Contains(p);
            }
        }
    }
