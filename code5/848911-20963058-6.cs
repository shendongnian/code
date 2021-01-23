    class Problematic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object Offender 
        {
            get { throw new NullReferenceException(); }
        }
    }
