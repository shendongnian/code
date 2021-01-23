       public partial class GeneralMcmMessage : UserControl, INotifyPropertyChanged
        {
            private int _messageId;
    
            public int MessageId
            {
                get
                {
                    return _messageId;
                }
    
                set
                {
                    _messageId = value;
                    OnPropertyChanged("MessageId");
                }
            }
    
            private DateTime _timeStamp;
    
            public DateTime TimeStamp
            {
                get
                {
                    return _timeStamp;
                }
    
                set
                {
                    _timeStamp = value;
    
                    OnPropertyChanged("TimeStamp");
                }
            }
    
            public GeneralMcmMessage()
            {
                InitializeComponent();
    
               //don’t set data context here
               //DataContext = this;
            }
    
        }
