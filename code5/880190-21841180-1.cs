    public void BindddlOrg()
        {
            List<XmlValue > list = RetrieveDataFromXml.GetAllOrg();
            
            ddlOrg.ItemsSource = list;
            
            ddlOrg.Items.Insert(0, new XmlValue (){nqme = "Select Org", value=-1});
        }
