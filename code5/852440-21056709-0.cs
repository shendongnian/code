        private WorksiteAddress _worksiteToEdit { get; set; }
        public WorksiteAddress WorksiteToEdit 
        {
            get 
            {
                if (_worksiteToEdit != null) return _worksiteToEdit;
                if (WorksiteId != null)
                {
                    using (var db = new YourDALContext())
                    {
                        _worksiteToEdit = db.WorksiteAddresses.FirstOrDefault(x => x.Id == WorksiteId);
                    }
                }
                if(_worksiteToEdit == null) _worksiteToEdit = new WorksiteAddress();
                return _worksiteToEdit;
            }
            set { _worksiteToEdit = value; }
        }
        [Required, DisplayName("Address")]
        public string StreetAddress
        {
            get { return WorksiteToEdit.StreetAddress; }
            set { WorksiteToEdit.StreetAddress = value; }
        }
        [Required]
        public string City
        {
            get { return WorksiteToEdit.City; }
            set { WorksiteToEdit.City = value; }
        }
        [Required]
        public string State
        {
            get { return WorksiteToEdit.State; }
            set { WorksiteToEdit.State = value; }
        }
        [Required, DisplayName("Zip Code")]
        public string ZipCode
        {
            get { return WorksiteToEdit.ZipCode; }
            set { WorksiteToEdit.ZipCode = value; }
        }
