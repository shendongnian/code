        object currentListItem;
        public object СurrentListItem
        {
            get => сurrentListItem;
            set
            {
                if (сurrentListItem != value)
                {
                    сurrentListItem = value;
                    OnPropertyChanged(nameof(СurrentListItem));
                }
            }
        }
