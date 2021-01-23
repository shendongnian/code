        [XmlIgnore]
        public ListManager<string> QualificationList
        {
            get
            {
                return qualification as ListManager<string>;
            }
        }
        [XmlElement("Qual")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string[] QualificationArray
        {
            get
            {
                return Enumerable.Range(0, qualification.Count).Select(i => qualification.GetElement(i)).ToArray();
            }
            set
            {
                // Here I am assuming your ListManager<string> class has Clear() and Add() methods.
                qualification.Clear();
                if (value != null)
                    foreach (var str in value)
                    {
                        qualification.Add(str);
                    }
            }
        }
