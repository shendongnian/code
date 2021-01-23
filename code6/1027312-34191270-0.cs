        private Guid id = Guid.Empty;
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [HiddenInput(DisplayValue = false)]
        public Guid CompanyId
        {
            get
            {
                if(id==Guid.Empty)
                    id = new Guid();
                return id;
            }
            set { id = value; }
        }
