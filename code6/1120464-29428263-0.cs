    public class YogaSpaceEvent
    {
    public int YogaSpaceEventId { get; set; }
    public int YogaSpaceID { get; set;}
    [ForeignKey("YogaSpaceID")]
    public virtual YogaSpace YogaSpace {get; set;}
    public string Title { get; set; }
    public DateTime DateTimeScheduled { get; set; }
    public int AppointmentLength { get; set; }
    public int StatusEnum { get; set; }
    }
