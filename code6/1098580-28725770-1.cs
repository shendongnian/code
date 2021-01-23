        public decimal Value
        {
            get { return this.value; }
            set
            {
                if (value == this.value) return;
                this.value = value;
                OnPropertyChanged("ValueString");
            }
        }
        public string ValueString
        {
            get { return this.value.ToString(CultureInfo.CurrentCulture); }
        }
