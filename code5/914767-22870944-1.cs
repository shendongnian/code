        private string _orgId;
        public string OrgId
        {
            get { return _orgId; }
            set { _orgId = value; RaisePropertyChanged("OrgId"); }
        }
