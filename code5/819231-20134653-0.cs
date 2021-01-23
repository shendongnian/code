    public class ProbeEntriesEntriesProbeEntry
    {
        private ProbeEntriesEntriesProbeEntryAnswers[] answersField;
        /// <remarks/>
       [XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
       [XmlArrayItemAttribute("string", typeof(ProbeEntriesEntriesProbeEntryAnswers), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public ProbeEntriesEntriesProbeEntryAnswers[] Answers
        {
            get
            {
                return this.answersField;
            }
            set
            {
                this.answersField = value;
            }
        }
    }
