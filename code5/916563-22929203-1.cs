    public double SL
    {
        get
        {
            if(bp == null || ep == null)
                sl = 0.0;
            else
                //Formula for slope of a line
                sl = (ep.Y - bp.Y) / (ep.X - bp.X);
            return sl;
        }
    }
    
    public double LI
    {
        get
        {
            //Use Euclidean distance to get length of line
            if(bp == null || ep == null)
                li = 0.0;
            else
                li =  Math.Sqrt(Math.Pow(bp.X - ep.X, 2) + Math.Pow(bp.Y - ep.Y, 2));
            return li;
        }
    }
    
    public override string ToString()
    {
        return "Slope = " + sl.ToString("F2") + "\n" + "\n" + "Length = " + li.ToString("F2");
    }
