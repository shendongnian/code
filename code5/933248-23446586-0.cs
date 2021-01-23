    public string ContentText { get; set; }
        
    private _xmlDocuent;    
    [NotMapped] 
    public XmlDocument Content 
    {
      get { return _xmlDocumet ?? (_xmlDocument = new XmlDocuent.Parse(ContentTExt)); }
    }
