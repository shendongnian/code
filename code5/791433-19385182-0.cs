    public class DrawDate {
        public int DayId { get; set; }
        public int LotteryId { get; set; }
        public string DayName { get { return Enum.GetName(typeof(MediaBug.Shared.Enumerators.Days), DayId); } }
        // other properties here if applicable
    }
