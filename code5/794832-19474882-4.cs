        public class SharingManager
        {
            // Define a global static event to be fired when the value is changing
            public static event EventHandler<NumericEventArgs> ValueChanged;
            public static int GlobalValue
            {
                set
                {
                    // Fire ValueChanged event
                    if (ValueChanged != null)
                        ValueChanged(null, new NumericEventArgs(value));
                 }
             }
          }
         public class NumericEventArgs : EventArgs
         {
            public NumericEventArgs(int value)
            {
                Value = value;
             }
             public int Value { get; set; }
         }
