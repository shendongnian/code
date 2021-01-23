    partial class Goal
    {
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public DateTime DateTrunc
        { 
            get { return this.Date.Date; }
        }        
    }
