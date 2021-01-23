     public class Vehicle
        {
            [Key]
            public int VehicleId { get; set; }
    
            public int FleetId { get; set; }
    
            public virtual ICollection<VehicleAttribute> VehicleAttributes { get; set; }
        }
    int fleetId = 1;
    int attributeId = 1;
    var q = from v in ctx.Vehicles
        where v.FleetId == fleetId
        select
            new
            {
                v.VehicleId,
                v.VehicleAttributes,
                SortingAttribute = v.VehicleAttributes.FirstOrDefault(va => va.AttributeId == attributeId)
            }
        into output
        orderby output.SortingAttribute.Value descending
        select output;
