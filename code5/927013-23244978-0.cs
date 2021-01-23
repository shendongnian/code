    public class CustomerLanguage : IDbIdentity 
    {
        public Guid Id { get; set; }
        public virtual DocumentLanguage DocumentLanguage { get; set; }
        public string Name { get { return DocumentLanguage.Name; } }
    }
    public List<CustomerLanguage> CurrentCustomerLanguageList
    {
        get { return _currentCustomerLanguageList; }
        set
        {
            _currentCustomerLanguageList = value;
            bsCustomerLanguages.DataSource = value;
            cbLanguage.DataSource = bsCustomerLanguages.DataSource;
            cbLanguage.DisplayMember = "Name";//Just name
            cbLanguage.ValueMember = "Id";
        }
    }
