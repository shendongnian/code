    void main()
    {
       Point a = new Point { x = 1, y = 2 }; // point1
       Point b = new Point { x = 3, y = 4 }; // point2
       DoSomething(a, b);
       // a and b are Changed!
    }
    
    public void DoSomething(Point a, Point b)
    {
       a.x = 53;
       b.y = 21;
    }
