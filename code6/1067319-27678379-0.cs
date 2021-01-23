    public class CheckBoxViewModel
    {
        public List<CheckBoxList> CheckBoxLists { get; set; }
    }
    
    public class CheckBoxList
    {
        public int CheckBoxId { get; set; }
        public string CheckBoxDescription { get; set; }
        public bool CheckBoxState { get; set; }
    }
