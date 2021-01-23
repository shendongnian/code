    void ReadFromDnsServerList()
    {
        _nameValueDictionary = new Dictionary<string, string>();
        XDocument doc = XDocument.Load("DnsServerList.xml");
        if (doc.Root != null)
        {
            var keyValueXml = from c in doc.Root.Descendants("Dns")
                select new
                {
                    name = c.Element("Name").Value,
                    value = c.Element("Value").Value
                };
            foreach (var info in keyValueXml)
            {
                _nameValueDictionary.Add(info.name, info.value);
            }
            cmbDns.DisplayMember = "Key";
            cmbDns.ValueMember = "Value";
            cmbDns.DataSource = _nameValueDictionary.ToArray();
        }
    }
