    public static bool operator ==(Giraffe g1, Giraffe g2)
    {
      if (g1 == (object)null && g2 != (object)null
        || g1 != (object)null && g2 == (object)null)
      {
        return false;
      }
      // rest of operator body here ...
    }
