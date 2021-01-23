    /// <summary>
    /// Creates a new instance of <code>PointExtend</code>
    /// </summary>
    /// <param name="x">...</param>
    /// <param name="y">...</param>
    /// <param name="r">...</param>
    /// <param name="g">...</param>
    /// <param name="b">...</param>
    /// <exception cref="InvalidColorValueException">Should the provided rgb values be out of range</exception>
    public PointExtend(double x, double y, int r, int g, int b)
            : base(x, y)
        {            
                var color = new Color(r, g, b);
                Color = color;                            
        }
