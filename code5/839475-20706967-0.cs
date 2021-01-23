    public interface Comparable
        {
            double SizeOf();
        }
    
        public delegate bool GreaterOf(Comparable obj1, Comparable obj2);
        
        public struct Point
        {
            private bool GetSizeOf(Comparable obj1, Comparable obj2)
            {
            return obj1.SizeOf() > obj2.SizeOf();
            }
    
            private GreaterOf _pointGreaterOf;
    
            public Point(object a)
                : this()
            {
                var v = a; //it make no sense as is only there to prove the property assignment.
                PointGreaterOf = GetSizeOf;
            }
    
            public GreaterOf PointGreaterOf
            {
                get { return _pointGreaterOf; }
                set { _pointGreaterOf = value; }
            }
        }
    
        public struct Trigangle
        {
            public GreaterOf TrigangleGreaterOf { get; set; }
    
            private bool GetSizeOf(Comparable obj1, Comparable obj2)
            {
            return obj1.SizeOf() > obj2.SizeOf();
            }
    
            public Trigangle(object a)
                : this()
            {
                var v = a;//it make no sense as is only there to prove the property assignment.
                TrigangleGreaterOf = GetSizeOf;
            }
        }
    
        public struct Vector
        {
            public GreaterOf VectorGreaterOf { get; set; }
    
            private bool GetSizeOf(Comparable obj1, Comparable obj2)
            {
            return obj1.SizeOf() > obj2.SizeOf();
            }
    
            public Vector(object a)
                : this()
            {
            var v = a; //it make no sense as is only there to prove the property assignment.
                VectorGreaterOf = GetSizeOf;
            }
        }
