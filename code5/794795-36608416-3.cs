        public ICommand OnListItemTapped
        {
            get
            {
                return new Command(() =>
                {
                    Debug.WriteLine("Cliked");
                });
            }
        }
