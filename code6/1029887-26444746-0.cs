    public class MyVM
    {
        #region Properties
        #endregion
        public Dictionary<string, VMState> States;
    }
    public class VMState
    {
        public bool Create { get; set; }
        public bool Read { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
    }
