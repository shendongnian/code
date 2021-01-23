        /// <summary>
        /// Get or set the CoverContent Collection.
        /// </summary> 
        public ObservableCollection<CoverContentBO> CoverContentCollection
        {
            get { return this.m_oCoverContent; }
            set
            {
                if (this.m_oCoverContent != value)
                {
                    this.IsChanged = true;
                    RemoveEventhandlers(m_oCoverContent);
                    this.m_oCoverContent = value;
                    AddEventhandlers(m_oCoverContent);
                    RaisePropertyChanged("CoverContentCollection");
                }
            }
        }
        private void AddEventhandlers(ObservableCollection<CoverContentBO> oCoverContent)
        {
            foreach (var CoverContentBO in oCoverContent)
            {
                CoverContentBO.PropertyChanged +=CoverContentBO_PropertyChanged;
            }
            oCoverContent.CollectionChanged +=oCoverContent_CollectionChanged;
        }
        void oCoverContent_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            foreach (CoverContentBO CoverContentBO in e.OldItems)
            {
                CoverContentBO.PropertyChanged -=CoverContentBO_PropertyChanged;
            }
            foreach (CoverContentBO CoverContentBO in e.NewItems)
            {
                CoverContentBO.PropertyChanged +=CoverContentBO_PropertyChanged;
            }
        }
        void CoverContentBO_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsChanged")
            {
                IsChanged = true;
            }
        }
        private void RemoveEventhandlers(ObservableCollection<CoverContentBO> oCoverContent)
        {
            foreach (var CoverContentBO in oCoverContent)
            {
                CoverContentBO.PropertyChanged -=CoverContentBO_PropertyChanged;
            }
            oCoverContent.CollectionChanged -=oCoverContent_CollectionChanged;
        }
