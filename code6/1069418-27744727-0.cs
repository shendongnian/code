    class SampleCollection<T>
    {
        // Declare an array to store the data elements. 
        private T[] arr = new T[100];
    
        // Define the indexer, which will allow client code 
        // to use [] notation on the class instance itself. 
        // (See line 2 of code in Main below.)         
        public T this[int i]
        {
            get
            {
                // This indexer is very simple, and just returns or sets 
                // the corresponding element from the internal array. 
                return arr[i];
            }
            set
            {
                arr[i] = value;
            }
        }
    }
