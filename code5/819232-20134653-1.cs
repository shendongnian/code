    public class ProbeEntriesEntriesProbeEntryAnswers
    {
        private string stringField;
        [XmlText]
        public string String
        {
            get
            {
                return this.stringField;
            }
            set
            {
                this.stringField = value;
            }
        }
    }
