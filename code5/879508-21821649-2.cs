    public IEnumerable<RateRecord> ParseRates(IEnumerable<XElement> rates) {
        foreach(var rate in rates) {
        	yield return new RateRecord {
        		Id = rate.Attribute("id").Value,
        		Rate = rate.Element("Rate").Value,
        		Date = rate.Element("Date").Value
        	};
        }
    }
