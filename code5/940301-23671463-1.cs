     class Company
    {
        public string Title { get; set; }
    
        public virtual void ParseXml(XElement elem)
        {
            this.Title = elem.Element("Title").Value;
        }
    }
    
    class DerivedCompany : Company
    {
        public string Address { get; set; }
        public override void ParseXml(XElement elem)
        {
            base.ParseXml(elem);
            this.Address = elem.Element("Address").Value;
        }
    }
    
  
      class CompanyUtil
    {
    
        protected virtual Company GenerateRealCompany()
        {
            return new Company();
        }
        public  IEnumerable<Company>  ReadCompanies(XDocument document)
        {
            IList<Company>  companies=new List<Company>();
            foreach (var elem in document.Root.Elements())
            {
                var comp = GenerateRealCompany();
                comp.ParseXml(elem);
                companies.Add(comp);
            }
            return companies;
        }
    }
    
    class DerivedCompanyUtil:CompanyUtil
    {
        protected override Company GenerateRealCompany()
        {
            return new DerivedCompany();
        }
    }
    
