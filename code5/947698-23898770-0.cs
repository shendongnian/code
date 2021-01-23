    [Serializable()]
    public class Report {
        
        [XmlIgnore()]
        private AttachedFiles _attachedFiles;
        public Report() {
                attachedFiles = null;
        } // end constructor
    
        [XmlArray(ElementName = "AttachedFiles"), XmlArrayItem(ElementName = "AttachedFile")]
        public AttachedFiles Files {
                get { return _attachedFiles; }
                set { _attachedFiles = value; }
        } // end property Files
    
    } // end class Report
    
    [Serializable()]
    [XmlRoot("ReportList")]
    public class ReportList {
    
        [XmlIgnore()]
        private Report[] _reports;
    
        public ReportList() {
            _reports = null;
        } // end constructor
    
        [XmlArray(ElementName = "nodes"), XmlArrayItem(ElementName = "node")]
        public Report[] Reports {
                get { return _reports; }
                set { _reports = value; }
        } // end property Reports
    
    } // end class ReportList
    
    [Serializable()]
    public class AttachedFiles : List<string> {
    } // end class AttachedFiles
