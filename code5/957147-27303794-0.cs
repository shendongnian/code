    [GridColumn(Title = "Org.", SortEnabled = true, Width = "100")]
    public int? MemberOrgId { get; set; }
    [ForeignKey("MemberOrgId")
    [NotMappedColumn]
    public virtual MemberOrganizations Organization { get; set; }
