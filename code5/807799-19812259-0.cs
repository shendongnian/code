    public static void CastAndContinue<T>(object toCast, Action<T> nextStep)
    {
      if (toCast is T)
        nextStep((T)toCast);
    }
