    public sealed class Reference<T>
    {
      public T Value { get; set; }
    }
    ...
    Reference<CustomObject> myCO1 = new Reference<CustomObject>()
                                    {
                                      Value = new CustomObject("A");
                                    };
    Reference<CustomObject> myCO2 = myCO1;
    CustomObject myCO3 = new CustomObject("B");
    myCO1.Value = myCO3;
