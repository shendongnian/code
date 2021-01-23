        public void CheckObject()
        {
            object test = 10;
            test = test + 10;    // Compile time error
            test = "hello";      // No error, Boxing happens here
        }
