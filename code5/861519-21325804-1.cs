    public IEnumerable<myclass> SubSet {
        get {
            return from x in IDList 
                    where masterListOfMyClass.ContainsKey(x)
                    select masterListOfMyClass[x]
        }
    }
