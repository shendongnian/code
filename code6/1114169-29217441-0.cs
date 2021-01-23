    private bool someProperty = false;
        public bool SomeProperty
        {
            get { return someProperty = false; }
            set { Set(() => SomeProperty, ref someProperty, value); }
        }
        private RelayCommand someCommand;
        public RelayCommand SomeCommand
        {
            get
            {
                return someCommand ??
                    new RelayCommand(() =>
                {
                    //SomeCommand actions
                }, () =>
                {
                    //CanExecute
                    if (SomeProperty)
                        return true;
                    else
                        return false;
                });
            }
        }
