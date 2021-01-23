    public class Order
    {
        [XmlAttribute("ObjectType")]
        public string TypeName
        {
            get;
            set;
        }
        [XmlAttribute("ID")]
        public string ID
        {
            get;
            set;
        }
        [XmlAttribute("TID")]
        public string TID
        {
            get;
            set;
        }
        [XmlIgnore]
        public Command Command
        {
            get;
            set;
        }
        [XmlAttribute("Command")]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [Browsable(false)]
        public string CommandName
        {
            get
            {
                return Command == null ? null : Command.Name;
            }
            set
            {
                // Logic to convert CommandName to Command, e.g.:
                Command = Command.FindByName(value); // or whatever.
            }
        }
        public Order()
        {
        }
    }
