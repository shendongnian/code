        public ICommand SelectAllCommand
        {
            get
            {
                return this.selectAllCommand ?? (this.selectAllCommand = new DelegateCommand(SelectAll, delegate(object obj) { return Thumbnails.Any(t => !t.IsChecked); }));
            }
        }
