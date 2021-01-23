    public class Sample
    {
        public double ValueChannel1
        {
            get;
            set;
        }
        public double ValueChannel2
        {
            get;
            set;
        }
        // etc.
    }
    public class SampleList
    {
        /* that's the list we're enwrapping. 
         * SampleList could also be inherited from List<Sample>, but in general this approach is less recommended -
         * read up on "composition over inheritance". */
        private List<Sample> _samples = new List<Sample>();
                
        /// <summary>
        /// Caches the lowest known value of ValueChannel1 property
        /// </summary>
        public double? ValueChannel1Minimum // it's a nullable double, because while the list is still empty, minimums and maximums have no value yet
        {
            get;
            private set;
        }
        public double? ValueChannel1Maximum { get; private set; }
        public double? ValueChannel2Minimum { get; private set; } 
        public double? ValueChannel2Maximum { get; private set; }
        public void Add(Sample sample)
        {
            if (sample == null)
            {
                throw new ArgumentNullException("sample");
            }
            // have you beat the record?
            if (sample.ValueChannel1 <= (ValueChannel1Minimum ?? double.MaxValue))
            {                
                // note: the essence of the trick with ?? operator is: if there's no minimum set yet, pretend the minimum to be the biggest value there is.
                // practically speaking, it ensures that the first element added to the list
                // sets the new minimum, whatever value that element had.
                ValueChannel1Minimum = sample.ValueChannel1;
            }
            if (sample.ValueChannel1 >= (ValueChannel1Maximum ?? double.MinValue))
            {
                ValueChannel1Maximum = sample.ValueChannel1;
            }
            
            // etc. for other properties
            _samples.Add(sample);
        }
        public List<Sample> ToList()
        {
            return _samples;
        }
    }
