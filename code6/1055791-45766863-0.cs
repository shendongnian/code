        private Page _dataExplorerContent;
        public Page DataExplorerContent
        {
            get { return _dataExplorerContent; }
            set
            {
                if(value != null)
                {
                    contentFrame.Navigate(value)
                    SetField(ref _dataExplorerContent, value);
                }
            }
        }
