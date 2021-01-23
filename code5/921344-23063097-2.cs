    public class Task
    {
        [Ignore]
        public string[] Attempts { get; set; }
        public string AttemptsMetadata
        {
            get
            {
                return Attempts != null && Attempts.Any()
                    ? Attempts.Aggregate((ac, i) => ";" + ac + i).Substring(1)
                    : null;
            }
            set { Attempts = value.Split(';'); }
        }
    }
