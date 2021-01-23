    abstract class AbsSum2 : AbsSum1, ISum
    {
      // Since the base class already has a **public** Sum() method with proper signature
      // ISum will use the method declared in the base class.
    }
