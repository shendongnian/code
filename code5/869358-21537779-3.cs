    byte[] octets = reader[0] as byte[] ;
    if ( octets == null )
    {
      Console.WriteLine( "{null}");
    }
    else
    {
      Console.WriteLine( "length={0:##0}, {{ {1} }}" , octets.Length , string.Join( " , " , octets.Select(x => string.Format("0x{0:X2}",x)))) ;
    }
