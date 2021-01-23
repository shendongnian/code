        /// <summary>
        /// Command which is fired when a list view item is selected in   the    main window 
        /// </summary>
        public RelayCommand SelectionChangedCmd { get; private set; }
       
        /// <summary>
        /// The listview item selected from the collection.
        /// </summary>
        public Feature SelectedAttributedMaster  { get; set; }
