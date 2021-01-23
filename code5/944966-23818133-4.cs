    class Group
    {
        private List<SpectralSet> _sets;
        public IEnumerable<SpectralSet> Sets { get { return _sets; } }
        public double? Resolution {get; private set;}
    
        public void Add(SpectralSet set)
        {
            var resolutionSet = _sets.FirstOrDefault(s => s.Resolution != null);
            if(resolutionSet != null && resolutionSet.Resolution != set.Resolution)
                //Throw the exception here
            _sets.Add(set);
            Resolution = set.Resolution;
        }
    
        public void Remove(SpectralSet set)
        {
            _sets.Remove(set);
            if(!_sets.Any())
                Resolution = null;
        }
    }
