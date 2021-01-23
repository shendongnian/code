    void Main()
    {
        unsafe
        {
            int x = 10;
            int* y = &x;
    
            Debug.WriteLine("x=" + x + ", y=" + *y);
    
            ChangeValue(ref x);
    
            Debug.WriteLine("x=" + x + ", y=" + *y);
    
            ChangeValue(ref *y);
    
            Debug.WriteLine("x=" + x + ", y=" + *y);
        }
    }
    
    static void ChangeValue(ref int value)
    {
        value += 10;
    }
