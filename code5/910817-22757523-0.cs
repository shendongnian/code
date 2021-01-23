    class Person
    {
        public long Id;//primary key
        public string Name;
    }
    class Responsibility
    {
        public long Id;//primary key
        public long PersonId;
        public long ResponsibleForId; 
    }
