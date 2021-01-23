        private const int VirtualListRadius = 1000;
        /// <summary>
        /// The collection constructor, runs the first step of the data filling.
        /// </summary>
        public ModelCollection()
        {
            //Fill in the virtual list with the default (mostly null) custom control.
            for (int i = 1; i <= VirtualListRadius; i++)
            {
                object LeftMostPage = NewPageControl(args1);
                object RightMostPage = NewPageControl(args2);
                Items.Insert(0, LeftMostPage);
                Items.Add(RightMostPage);
            }
        }        
        /// <summary>
        /// The FlipViewer's items list, with all the virtual content and real content (where applicable)
        /// </summary>
        public ObservableCollection<Object> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }
        public ObservableCollection<Object> _items = new ObservableCollection<Object>();
