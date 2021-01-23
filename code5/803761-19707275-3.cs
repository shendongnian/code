    protected void myMethod(Color? color,other parameters...) 
    {
        if (color == null) // or !Color.HasValue
        {
             // color-is-null logic
        }
        else
        {
             var col = color.Value; 
             // col is an instance of System.Drawing.Color
             // Use `col` instead of color from your current `myMethod` 
             // implementation
        }
    }
