    public class Hero : ISupportInitialize
    {
        public string Who
        { get; set; } = string.Empty;
        public string What
        { get; set; } = string.Empty;
        public string Where
        { get; set; } = string.Empty;
        public void BeginInit()
        {
            // set a flag here if your property setters
            // have dependencies on other properties
        }
        public void EndInit()
        {
            if (string.IsNullOrWhiteSpace(Who))
                throw new Exception($"The property \"Who\" is missing");
            if (string.IsNullOrWhiteSpace(What))
                throw new Exception($"The property \"What\" is missing");
            // Where is optional...
        }
    }
