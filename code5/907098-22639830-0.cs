    public SomeSerializableClass SerializedProcess 
    {
      get {
         ConvertProcessToSomeSerializableClass(process);
      }
      set {
          process = ConvertSomeSerialzableClassToProcess(value);
      }
    }
