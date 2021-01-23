       private ICommand _CloseArticleCommand;
        public ICommand CloseArticleCommand
        {
            get { return _CloseArticleCommand; }
            set
            {
                _CloseArticleCommand = value;
                OnPropertyChanged("CloseArticleCommand");
            }
        }
