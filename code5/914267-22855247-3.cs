    public class user
    {
        string Firstname { get; set; }
        string Lastname { get; set; }
        List<photos> photos{get;set;};
        public User()
        {
             photos= new List<photos>();
        }
    }
