    public delegate bool ShapeTester(Point point);
    static public ShapeTester makeShape(int seed) {
        // initialization here
    
        ShapeTester inside = (Point q) => {
            // some math here
            return (myCondition);
        }
        return inside;
    }
