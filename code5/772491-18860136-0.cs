    namespace sarus.division.warehouse.cmms.infrastructure.data.logic.location.type
    {
        [DataContract]
        public class Type : actual.Actual
        {
            [DataMember]
            public List<location.Location> Locations { get; set; }
            
            ...
        }
    }
