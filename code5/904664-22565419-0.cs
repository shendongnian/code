    public class TrackitWorkOrder
    {
        public Dictionary<string, TrackItWorkOrderNote> Notes { get; set; }
        public int Id { get; set; }
        ...
    }
    public class TrackItWorkOrderNote
    {
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }     
        ...
    }
