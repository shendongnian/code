    // Have a [static] singleton Iron instance, but doesn't prevent
    // creation of new Iron instances..
    static class ResourceTable {
        public static Iron Iron = new Iron();
    };
    // Just an Iron instance; it doesn't matter where it comes from
    // (Because it is a 'singleton' the SAME instance is returned each time.)
    Iron iron = ResourceTable.Iron;    // or new Iron();
                                       //    [^- object ]
    // .. and it can be used the same
    string name = iron.name;           // or ResourceTable.Iron.name, eg.
    float unitMass = iron.unitMass;    //    [^- object too!  ]
    float totalMass = iron.totalMass;
