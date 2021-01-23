    class Group
    {
        private List<SpectralSet> _sets;
        public IEnumerable<SpectralSet> Sets { get { return _sets; } }
        public void Add(SpectralSet set)
        {
            //Do validation here, throw an exception or whatever you want to do if the set isn't valid
            _sets.Add(set);
        }
        //Have a similar Remove method
    }
