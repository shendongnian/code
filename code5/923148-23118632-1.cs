        public int GetHashCode(string value)
        {
            // for each index in value
            if (!char.IsSymbol(value, i))
                // add value[i].ToUpperInvariant() to the hash using an algorithm
                // like http://stackoverflow.com/a/263416/781792
        }
