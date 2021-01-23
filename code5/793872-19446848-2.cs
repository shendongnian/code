    public class CountriesComboBox : ComboBox
    {
    
        public CountriesComboBox()
        {
            XDocument obj = XDocument.Load("countries.xml");
            //DisplayMember = "countryiso";
            //ValueMember = "countrycode";
            DataSource = obj.Descendants("country").Select(x => new
            {
                countrycode = x.Attribute("code").Value,
                countryiso = x.Attribute("iso").Value
            }).ToList();
        }
    
    }
