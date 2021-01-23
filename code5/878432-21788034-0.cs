    public class QuestionViewModel
    {
        public int? Id { get; set; }
        
        [Required(ErrorMessage="Required")]
        public int QuestionType { get; set; }
    
        public string SubType { get; set; }
    
        public string Text { get; set; }
    
        public int SortOrder { get; set; }
    
        public bool IsHidden { get; set; }
    
        public int SelectedValue { get; set; }
    
        public List<QuestionOptionViewModel> Options { get; set; }
    }
