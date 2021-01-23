    public static double ComputeResult( double diameter , double height )
    {
      double result =   0.5
                      * (
                              ( (2.0*height) - diameter )
                            * Math.Sqrt( (height*diameter) - Math.Pow(height,2.0) )
                          +   (diameter/2.0)
                            * Math.Asin( 2.0*height -1.0 )
                            / diameter
                          + ( Math.PI * Math.Pow(diameter,2.0) )
                            / 2.0
                        ) ;
        return result ;
    }
