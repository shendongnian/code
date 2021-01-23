    void Main()
    {
            var names = new string[] {"Frank", "Jules", "Mark", "Allan", "Frank", "Greg", "Tim"};
            var listA = new List<string>();
            var listB = new List<string>();
            
            // I'm not entirely sure where this comes from other than it's always
            // the first element in the "names" list.
            var needle = names[0]; // "Frank"
            
            // this finds the location of the second "Frank"
            var splitLocation = Array.IndexOf(names, needle, 1);
            
            // here we grab the first elements (up to the splitLocation)
            listA = names.Take(splitLocation).ToList();
            // here we grab everything past the splitLocation
            // (starting with the second "Frank")
            listB = names.Skip(splitLocation).ToList();
    }
