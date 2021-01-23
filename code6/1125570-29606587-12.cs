    void main()
    {
       MyPoint a = new MyPoint { x = 1, y = 2 }; // point1
       MyPoint b = new MyPoint { x = 3, y = 4 }; // point2
       DoSomething(a, b);
       // a and b are Changed!
       Assert.AreEqual(53, a.x);
       Assert.AreEqual(21, b.y);
    }
    
    public void DoSomething(MyPoint a, MyPoint b)
    {
       a.x = 53;
       b.y = 21;
    }
