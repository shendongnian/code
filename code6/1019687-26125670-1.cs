    IList<Either<E, Exception>> Process(E e)
    {
      var results = new List<Either<E, Exception>>();
      results.Add(Process1(results.AsReadOnly()));
      results.Add(Process2(results.AsReadOnly()));
      ...
      results.Add(ProcessN(results.AsReadOnly()));
      return results.AsReadOnly();
    }
