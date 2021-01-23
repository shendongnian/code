    namespace Template.Models
    {
    using System;
    using System.Collections.Generic;
    
    public partial class Question
    {
        public Question()
        {
            this.QuestionOptions = new HashSet<QuestionOption>();
            this.Responses = new HashSet<Response>();
        }
    
        public int questionId { get; set; }
        public int eventId { get; set; }
        public int pageId { get; set; }
        public string question1 { get; set; }
        public int questionType { get; set; }
        public Nullable<int> linkedTo { get; set; }
        public Nullable<int> options { get; set; }
        public Nullable<int> ranking { get; set; }
    
        public virtual ICollection<QuestionOption> QuestionOptions { get; set; }
        public virtual QuestionType QuestionType1 { get; set; }
        public virtual ICollection<Response> Responses { get; set; }
        }
    }
