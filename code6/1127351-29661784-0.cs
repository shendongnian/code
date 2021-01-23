        public FTViewModel(int JobID)
        {
            _oFTrn = new ObservableFilesTransmitted(_dataDc, JobID);
            _oFTrn.CollectionChanged += oFTrnCollectionChanged;
            _oFTrn.FillCollection();
        }
