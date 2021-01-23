        private string company = "";
        private string ship = "";
        private string adress = "";
        private string city = "";
        private string zipCode = "";
        private string country = "";
        private string btw_nmbr = "";
        private bool isTempCustomer = true;
        private List<ContactData> phoneNumbers;
        private List<ContactData> eMailAdresses;
        private string fileName;
        #region public methods
        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                if (company.Trim() != value.Trim())
                {
                    company = value;
                    OnPropertyChanged("Company");
                }
            }
        }
        public string Ship
        {
            get
            {
                return ship;
            }
            set
            {
                if (ship.Trim() != value.Trim())
                {
                    ship = value;
                    OnPropertyChanged("Ship");
                }
            }
        }
        public string Adress
        {
            get
            {
                return adress;
            }
            set
            {
                if (adress.Trim() != value.Trim())
                {
                    adress = value;
                    OnPropertyChanged("Adress");
                }
            }
        }
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                if (city.Trim() != value.Trim())
                {
                    city = value;
                    OnPropertyChanged("City");
                }
            }
        }
        public string ZipCode
        {
            get
            {
                return zipCode;
            }
            set
            {
                if (zipCode.Trim() != value.Trim())
                {
                    zipCode = value;
                    OnPropertyChanged("ZipCode");
                }
            }
        }
        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                if (country.Trim() != value.Trim())
                {
                    country = value;
                    OnPropertyChanged("Country");
                }
            }
        }
        public string BTW_Nmbr
        {
            get
            {
                return btw_nmbr;
            }
            set
            {
                if (btw_nmbr.Trim() != value.Trim())
                {
                    btw_nmbr = value;
                    OnPropertyChanged("BTW_Nmbr");
                }
            }
        }
        public bool IsTempCustomer
        {
            get
            {
                return isTempCustomer;
            }
            set
            {
                isTempCustomer = value;
                OnPropertyChanged("IsTempCustomer");
            }
        }
        public List<ContactData> PhoneNumbers
        {
            get
            {
                return phoneNumbers;
            }
            set
            {
                phoneNumbers = value;
                OnPropertyChanged("PhoneNumbers");
            }
        }
        public void AddPhoneNumber(ContactData cd)
        {
            phoneNumbers.Add(cd);
            OnPropertyChanged("PhoneNumbers");
        }
        public List<ContactData> EmailAdresses
        {
            get
            {
                return eMailAdresses;
            }
            set
            {
                eMailAdresses = value;
                OnPropertyChanged("EmailAdresses");
            }
        }
        public void AddEmailAdress(ContactData cd)
        {
            eMailAdresses.Add(cd);
            OnPropertyChanged("EmailAdresses");
        }
        public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
                OnPropertyChanged("FileName");
            }
        }
        #endregion
    }
