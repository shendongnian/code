    class SportsParent
    {
        //Code for MsgTypes was not provided so it is commented out
        public List<SportGroup> Sports { get; set; }
    }
    class SportGroup
    {
        public SportItem Sport { get; set; }
    }
    class SportItem
    {
        public int Id { get; set; }
        public int Import_id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }    //need to be converted to bool instead of int
        public int Order { get; set; }
        public int Min_bet { get; set; }
        public int Max_bet { get; set; }
        public int Updated { get; set; }
        public string Feed_type { get; set; }
        public string Locale { get; set; }
    }
