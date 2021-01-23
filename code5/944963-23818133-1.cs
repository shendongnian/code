    class Group
    {
        private List<SpectralSet> _sets;
        public IEnumerable<SpectralSet> Sets { get { return _sets; } }
        public readonly double Resolution;
        public Group(double resolution)
        {
            Resolution = resolution;
        }
        public void Add(SpectralSet set)
        {
            if(set.Resolution != resolution)
                //Throw an Exception here, or however you want to handle invalid data
            _sets.Add(set);
        }
        //Have a similar Remove method
    }
