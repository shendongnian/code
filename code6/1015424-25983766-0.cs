    try
    {
        TheString = SomeDangerousMethod();
    }
    catch
    {
      try
      {
          TheString = SomeSaferMethod();
      }
      catch
      {
          TheString = SuperSaferMethod();
      }
    }
    return TheString;
