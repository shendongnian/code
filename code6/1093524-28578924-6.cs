    public class ResxFile
    {
        #region fields
        private XDocument doc; //this is the aggregate
        private IResxFileDataNode[] nodes;
        
        #endregion
        #region properties
        public IResxFileDataNode[] DataNodes { get { return nodes; } }
        #endregion
        #region construction
        //private constructor to avoid missuse of the class
        private ResxFile(string path)
        {
            this.doc = XDocument.Load(path);
        }
        //use this instead
        public static ResxFile Load(string path)
        {
            ResxFile result = new ResxFile(path);
            result.CreateDataNodes();
            return result;
        }
        #endregion
        #region methods
        private void CreateDataNodes()
        {
            this.nodes = doc.Descendants("data").Select(n => new ResxFileDataNode(n)).ToArray();
        }
        public void Save(string path)
        {
            this.doc.Save(path);
        }
        #endregion
    }
    public interface IResxFileDataNode : INotifyPropertyChanged
    {
        string Name { get; } //readonly field
        string Value { get; set; } //this you can edit
        string Font { get; set; } // i'd bind this to a combobox with all possible values
        string DateStamp { get; } //i assume this is readonly and will be set to the current time once you update the fields
        string Comment { get; set; }
    }
    public class ResxFileDataNode : IResxFileDataNode
    {
        #region fields
        private static readonly Regex fontRegex = new Regex(@"(?<=\[Font\]).*?(?=\[/Font\])");
        private static readonly Regex dateRegex = new Regex(@"(?<=\[DateStamp\]).*?(?=\[/DateStamp\])");
        private static readonly Regex commentRegex = new Regex(@"(?<=\[Comment\]).*?(?=\[/Comment\])");
        private static readonly string dateTimeFormat = "yyyy/dd/MM HH:mm:ss";
        private XElement node; //this is the aggregate
        private XElement valueNode;
        private XElement commentNode;
        private string name;
        private string value;
        private string font;
        private DateTime dateTime;
        private string comment;
        
        #endregion
        #region properties
        public string Name
        {
            get { return this.name; }
        }
        public string Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
                valueNode.Value = this.value;
                UpdateTimeStamp();
                OnPropertyChanged("Value");
            }
        }
        public string Font
        {
            get
            {
                return this.font;
            }
            set
            {
                this.font = value;
                UpdateTimeStamp();
                OnPropertyChanged("Font");
            }
        }
        public string DateStamp
        {
            get { return this.dateTime.ToString(dateTimeFormat); }
        }
        public string Comment
        {
            get
            {
                return this.comment;
            }
            set
            {
                this.comment = value;
                UpdateTimeStamp();
                OnPropertyChanged("Comment");
            }
        }
        
        #endregion
        #region construction
        public ResxFileDataNode(XElement dataNode)
        {
            this.node = dataNode;
            this.valueNode = dataNode.Element("value");
            this.value = this.valueNode.Value;
            this.commentNode = dataNode.Element("comment");
            this.name = dataNode.Attribute("name").Value;
            this.comment = commentRegex.Match(this.commentNode.Value).Value;
            this.font = fontRegex.Match(this.commentNode.Value).Value;
            DateTime d;
            if (DateTime.TryParseExact(dateRegex.Match(this.commentNode.Value).Value, dateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out d))
            {
                this.dateTime = d;
            }
        }
        #endregion
        #region methods
        private void OnPropertyChanged(string propertyName)
        { 
            PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
        }
        private void UpdateTimeStamp()
        {
            this.dateTime = DateTime.Now;
            UpdateCommentNode();
            OnPropertyChanged("DateStamp");
        }
        private void UpdateCommentNode()
        {
            this.commentNode.Value = string.Format("[Font]{0}[/Font][DateStamp]{1}[/DateStamp][Comment]{2}[/Comment]", this.font.ToString(), this.dateTime.ToString(dateTimeFormat,CultureInfo.InvariantCulture), this.comment);
        }
        #endregion
        #region events
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        #endregion
    }   
