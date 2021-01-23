    [ExactlyOneRequired(nameof(WheelChairId), nameof(WheelChair))]
    public class Train
    {
        public int? WheelChairId { get; set; }
        public WheelChair WheelChair { get; set; }
    }
