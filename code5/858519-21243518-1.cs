    public static double ComputeResult( double diameter , double height )
    {
      double t1 = ( (2.0*height) - diameter )
                * Math.Sqrt( (height*diameter) - Math.Pow(height,2.0) )
                ;
      double t2 = ( diameter / 2.0 )
                * Math.Asin(2.0*height-1.0)
                / diameter
                ;
      double t3 = ( Math.PI * Math.Pow(diameter,2.0) )
                / 2.0
                ;
      double result = 0.5 * ( t1 + t2 + t3 ) ;
      return result ;
    }
   
