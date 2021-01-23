    public class PollVM
    {
        public PollVM()
        {
            this.Choices = new List<KeyValuePair<string, int>>();
        }
        public int ID { get; set; }
        public string Question { get; set; }
        public bool IsMultipleChocie { get; set; }
        public DateTime? ExperationDate { get; set; }
        public List<KeyValuePair<string, int>> Choices { get; set; }
        public List<string> VotedIPs { get; set; }
        public List<int?> VotedUserIDs { get; set; }
    }
