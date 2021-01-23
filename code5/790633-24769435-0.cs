    {
    "Shifts": [
        {
            "Shift": {
                "ShiftID": 126604,
                "Name": "Volunteers - High Intensity",
                "Description": "sfsd",
                "Venue": "",
                "StartDateTime": "2014-01-28T12:00:00",
                "EndDateTime": "2014-01-28T16:30:00",
                "LocationN": "0.0",
                "LocationE": "0.0"
            }
        }
    ]
    }
    public class Shift2
    {
        public int ShiftID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Venue { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public string LocationN { get; set; }
        public string LocationE { get; set; }
    }
    
    public class Shift
    {
        public Shift2 Shift { get; set; }
    }
    
    public class RootObject
    {
        public List<Shift> Shifts { get; set; }
    }
