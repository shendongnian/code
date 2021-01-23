      CustomerList csl = new CustomerList();
                    csl.customers = new List<Customer>();
                    Customer cs = new Customer();
        csl.customers.Add(cs);
      XmlSerializer xs = new XmlSerializer(typeof(CustomerList));
                using(MemoryStream ms = new MemoryStream())
    	        {
                    xs.Serialize(ms, csl);
                    File.WriteAllBytes("temp.xml", ms.ToArray());
            	}
