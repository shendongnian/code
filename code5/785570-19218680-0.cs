    void Main()
    {
        unsafe
        {
            int x = 10;
            int* y = &x;
            
            Debug.WriteLine("x=" + x + ", y=" + *y);
            
            x = 20;
            
            Debug.WriteLine("x=" + x + ", y=" + *y);
        }
    }
