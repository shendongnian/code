    public bool IsExactlyRepresentableAsIeee754Double( decimal value )
    {
      // An IEEE 754 double has 53 bits of precision (52 bits of which are explicitly stored).
      const decimal ieee754MaxBits = 0x001FFFFFFFFFFFFF ;
      
      // move the decimal place right until the decimal's absolute value is integral
      decimal n = Math.Abs(value) ;
      while ( Decimal.Floor(n) != n )
      {
        n *= 10m;
      }
      
      bool isRepresentable = n <= ieee754MaxBits ;
      return isRepresentable ;
    }
