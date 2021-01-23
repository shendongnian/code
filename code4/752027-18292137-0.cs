    struct Point
    {
    	int x, y;
    	public Point(int x, int y) {
    		this.x = x;
    		this.y = y;
    	}
    	public int X {
    		get { return x; }
    		set { x = value; }
    	}
    	public int Y {
    		get { return y; }
    		set { y = value; }
    	}
    }
    struct Rectangle
    {
    	Point a, b;
    	public Rectangle(Point a, Point b) {
    		this.a = a;
    		this.b = b;
    	}
    	public Point A {
    		get { return a; }
    		set { a = value; }
    	}
    	public Point B {
    		get { return b; }
    		set { b = value; }
    	}
    }
