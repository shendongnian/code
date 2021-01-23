        public virtual ICollection<Phone> _phones { get;  set; }
        [NotMapped]
        public virtual ICollection<Phone> Phones
        {
            get { return this._phones == null ? new List<Phone>() : this._phones.Where(a => a.IsDeleted == false).ToList<Phone>(); }
            set { this._phones = value; }
        }
