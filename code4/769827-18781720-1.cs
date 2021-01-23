    class SomeCaptureContext {
        public DateTime? date; // yes, a public field - needs to support 'ref' etc
        public bool SomePredicate(string x) // the actual name is horrible
        {
            return this.date.GetValueOrDefault()
                  .Date.ToString(CultureInfo.InvariantCulture) == x;
        }
    }
    
