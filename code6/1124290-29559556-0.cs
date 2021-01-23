    void Main()
    {
        int ix = 1;
        int iy = 2;
        dynamic ox = ix;
        dynamic oy = iy;
    
        if (ox < oy)
            Debug.WriteLine("ox < oy");
        else if (ox == oy)
            Debug.WriteLine("ox == oy");
        else
            Debug.WriteLine("ox > oy");
    }
