    public virtual FacilityRequestor Requestor { get; set; }
    public virtual FacilityHardwareRequestDescription WorkType { get; set; }
    public virtual FacilityLocation EquipmentLocation { get; set; }
    public virtual FacilityCostCenter CostCenter { get; set; }
    public virtual HardwareConnector Connector { get; set; }
    public virtual FacilityLocation ConnectorLocation { get; set; }
    public virtual FacilityPlannerRequestStatus PlannerRequestStatus { get; set;}
