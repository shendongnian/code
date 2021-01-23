    public class Class : INotifyPropertyChanged, IEditableObject
    {
        private int _rowNum;
        public int RowNum
        {
            [DebuggerStepThrough]
            get { return _rowNum; }
            [DebuggerStepThrough]
            set
            {
                if (value != _rowNum)
                {
                    _rowNum = value;
                    OnPropertyChanged("RowNum");
                }
            }
        }
        private string _input;
        public string Input
        {
            [DebuggerStepThrough]
            get { return _input; }
            [DebuggerStepThrough]
            set
            {
                if (value != _input)
                {
                    _input = value;
                    OnPropertyChanged("Input");
                }
            }
        }
        private string _output;
        public string Output
        {
            [DebuggerStepThrough]
            get { return _output; }
            [DebuggerStepThrough]
            set
            {
                if (value != _output)
                {
                    _output = value;
                    OnPropertyChanged("Output");
                }
            }
        }
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            var handler = System.Threading.Interlocked.CompareExchange(ref PropertyChanged, null, null);
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
        #region IEditableObject Implementationi
        public void BeginEdit()
        {
            // your implementation goes here
        }
        public void CancelEdit()
        {
            // your implementation goes here
        }
        public void EndEdit()
        {
            // your implementation goes here
        }
        #endregion
    }
