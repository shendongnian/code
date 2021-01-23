    public class Order
    {
        private string name;
        [XmlAttribute("Name")]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    SetupCommandIfPossible();
                }
    
            }
        }
    
        private string tid;
        [XmlAttribute("TID")]
        public string TID
        {
            get
            {
                return tid;
            }
            set
            {
                if (tid != value)
                {
                    tid = value;
                    SetupCommandIfPossible();
                }
            }
        }
    
    
        private Command command;
        [XmlAttribute("Command")]
        public string Command
        {
            get
            {
                return command.Name;
            }
            set
            {
                SetupCommandIfPossible();
            }
        }
    
        public void SetupCommandIfPossible()
        {
             if (!string.IsNullOrEmpty(tid) && !string.IsNullOrEmpty(name) && command == null)
             {             
                command = new Command(TID, Name);
             }
        }
    
        public Order()
        {
    
        }
    }
