    var query = from s in entity.Sources
                where s.CorporationId == corporationId
                select new SourceItem(s);
    class SourceItem
    {
      private SourceEntity _model;
      public SourceItem(SourceEntity model)
      {
          _model = model;
      }
      public Guid CorporationId
      {
        get { return _mode.CorporationId; }
        set
        {
          _model.CorporationId = value;
          OnPropertyChanged(this, "CorporationId");
        }
      }
    }
