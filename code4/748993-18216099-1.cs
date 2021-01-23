        private long totalSize ;
        public long TotalSize
        {
            get{return this.totalSize;}
            set {
                if( this.totalSize != value )
                {
                    this.totalSize = value;
                    NotifyPropertyChanged("TotalSize");
                }
            }
        }
