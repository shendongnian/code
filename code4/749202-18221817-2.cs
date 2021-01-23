    public XElement TransformSearchResult(SearchResult result)
    {
    	return new XElement("SearchResult",
    		new XElement("SBE_PCB_Data", new XAttribute("PCBID", result.PCBID)),
    		new XElement(result.EventType,
    			new XAttribute("ActionID", result.ActionId),
    			new XAttribute("User", result.UserAndIP),
    			new XAttribute("Date", result.Date),
    			new XAttribute("PCBID", result.PCBID)),
    		new XElement("Reason", result.Reason));
    }
