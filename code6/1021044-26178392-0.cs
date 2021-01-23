        [XmlIgnore]
		public TimeSpan[] TimeSpanArrayField;
        [Browsable(false)]
        [XmlElement(DataType = "duration", ElementName = "TimeSpanField")]
        public string[] TimeSpanFieldString
        {
            get
            {
                string[] strings = new string[TimeSpanArrayField.Length];
                for (int number = 1; number <= TimeSpanArrayField.Length; number++)
                    strings[number - 1] = TimeSpanArrayField[number - 1].ToString();
                return strings;
            }
            set
            {
                TimeSpanArrayField = new TimeSpan[value.Length];
                for (int number = 1; number <= value.Length; number++)
                    TimeSpanArrayField[number - 1] = TimeSpan.Parse(value[number - 1]);
            }
        }
