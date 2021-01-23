    public class Scavenger
    {
        private readonly dynamic _lookup;
        public Scavenger(dynamic lookup)
        {
            _lookup = lookup;
        }
        public string WhatIs(string key)
        {
            if (_lookup.ContainsKey(key)) return _lookup[key];
            return null;
        }
    }
