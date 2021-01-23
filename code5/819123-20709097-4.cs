    public static class ModelDefinedFunctions
    {
        [EdmFunction("TestDBModel.Store", "SampleFunction")]
        public static int SampleFunction(int param)
        {
          throw new NotSupportedException("Direct calls are not supported.");
        }
    }
