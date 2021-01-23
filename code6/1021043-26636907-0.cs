    public class Polygon : PlaneRegion<IEdge> 
    {
        public new List<LineSegment> PlaneBoundaries
        {
            get { return (_planeBoundaries); }
            set { _planeBoundaries = value; }
        }
        protected List<LineSegment> _planeBoundaries;
    }
