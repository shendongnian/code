    // Readonly mapping, virtual class
    // which ID role is playing column panel_CODE
    public PanelViewMapping()
    {
        Table("panel-table");
        Id(x => x.Code)
          .Column("panel_CODE")
          .GeneratedBy.Assigned();
        ...
