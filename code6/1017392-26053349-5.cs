    namespace MyLeave
    {
        // This is your modal. It defines how you'd hold your leave data in memory
        // This collection will hold all your leaves
        [Serializable]
        public class LeaveCollection : List<Leave> { }
    
        // Base class to create your leave
        [Serializable] // Since you are saving the object in ViewState you need to mark this class as Serializable
    
        public class Leave
        {
            public LeaveType LeaveType { get; set; }
            public int TotalDays { get; set; }
            public int Available { get; set; }
    
            public Leave(LeaveType type)
            {
                this.LeaveType = type;
                this.TotalDays = 0;
                this.Available = 0;
            }
        }
    
        // This Enum will hold the leave type
        public enum LeaveType
        {
            AL = 1,
            ML = 2,
            SP = 3
        }
    }
