    foreach(var item in List<T>)
    {
      if (item.GetType().Equals(typeof(fooClassA)))
      {
         ret = (item as fooClassA).VALUE_A;
      }
      if (item.GetType().Equals(typeof(fooClassB)))
      {
         ret = (item as fooClassB).VALUE_B;
      }
      ....
    }
