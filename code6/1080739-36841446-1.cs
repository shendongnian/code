    [ExactlyOneRequired(nameof(WheelId), nameof(Wheel))]
    public class Train
    {
        public int? WheelChairId { get; set; }
        public WheelChair WheelChair { get; set; }
    }
