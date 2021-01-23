    public abstract class DataValue {
        public string Category { get; protected set; } // value after /YD
        public string Name { get; protected set; } // value after /YD/XXX/
        public int DimensionCount { get; protected set; } // number of dimensions
        public int[] Dimensions { get; protected set; } // The size of each dimension
        protected void ParseHeader(string header) {
            // Split of the header into the Category/Name and set it
        }
        public virtual void ReadValue(string header, StreamReader reader) {
            ParseHeader(header);
        }
    }
