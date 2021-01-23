    public class Y_Equipment
    {
    	[MaxLength(150)]
    	public string CategoryDisplayName { get; set; }
    	[MaxLength(150)]
    	[Key]
    	[Index("IX_Y_Equipment", 2, IsUnique = true)]
    	public string CategoryCode { get; set; }
    	[MaxLength(150)]
    	public string EquipmentDisplayName { get; set; }
    	[MaxLength(150)]
    	[Index("IX_Y_Equipment", 3, IsUnique = true)]
    	public string EquipmentCode { get; set; }
    	public Int32 Timespamp { get; set; }
    
    	[Index("IX_Y_Equipment", 1, IsUnique = true)]
    	[ForeignKey("Unit")]
    	[MaxLength(15)]
    	public string Unit_Code { get; set; }
    
    	public virtual Y_Unit Unit { get; set; }
    }
