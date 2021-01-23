    public class Access
    {
        public enum Level
        {
            None = 10,
            Read = 20,
            ReadWrite = 30
        }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AccessId { get; set; }
        public string Name { get; set; }
    }
