    class OutputClass
    {
        private OutputClass()
        {
            // inaccessible to anything but OutputClass methods
        }
        public static OutputClass getOutputClass()
        {
            // Control the construction of the class here.
            return new OutputClass();
        }
      }
