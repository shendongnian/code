    public class Colleague
    {
        public int ColleagueId { get; set; }
        public int PersonId { get; set; }
        [Key]
        public string CombinedId {
            get { return ColleagueId.ToString() + PersonId.ToString(); }
        }
    }
