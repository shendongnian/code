    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    
    namespace PSA.Models
    {
        public class Issue
        {
            public virtual int IssueID { get; set; }
            [Required(ErrorMessage = "Title is Required.")]
            public virtual string Title { get; set; }
            public virtual string Description { get; set; }
            public virtual string Type { get; set; }
            public virtual string Classification { get; set; }
            public virtual bool Internal { get; set; }
            public virtual int ProbableClassificationId { get; set; }
            public virtual ProbableClassification ProbableClassification { get; set; }
            public virtual int SeverityClassificationId { get; set; }
            public virtual SeverityClassification SeverityClassification { get; set; }
            string ratingstatus;
            public virtual string Rating 
            {
                get 
                {
                    if (ProbableClassification != null && SeverityClassification != null)
                    {
                        if (SeverityClassification.Severity == "Minor")
                        {
                            ratingstatus = "Low";
                        }
                        if (ProbableClassification.Probability == "Not Likely" && SeverityClassification.Severity == "Medium")
                        {
                            ratingstatus = "Low";
                        }
                        if (ProbableClassification.Probability == "Likely" && SeverityClassification.Severity == "Medium")
                        {
                            ratingstatus = "Medium";
                        }
                        if (ProbableClassification.Probability == "Definitely" && SeverityClassification.Severity == "Medium")
                        {
                            ratingstatus = "Medium";
                        }
                        if (ProbableClassification.Probability == "Not Likely" && SeverityClassification.Severity == "Major")
                        {
                            ratingstatus = "Low";
                        }
                        if (ProbableClassification.Probability == "Likely" && SeverityClassification.Severity == "Major")
                        {
                            ratingstatus = "High";
                        }
                        if (ProbableClassification.Probability == "Definitely" && SeverityClassification.Severity == "Major")
                        {
                            ratingstatus = "Crtical";
                        }
    
                    }
                return ratingstatus;
                }
                set
                {
                    ratingstatus = value;
                }
            }
     
            [Display(Name = "Due Date")]
            [DataType(DataType.Date)]
            public virtual DateTime DueDate { get; set; }
    
            [Display(Name = "Assigned To")]
            public int StakeholderID { get; set; }
            public virtual Stakeholder Stakeholder { get; set; }
            [Display(Name = "Customer")]
            public int CustomerID { get; set; }
    
            public virtual Customer Customer { get; set; }
            [DataType(DataType.Date)]
            [ScaffoldColumn(false)]
            public virtual DateTime DateSubmitted { get; set; }
            public Issue()
            {
                this.DateSubmitted = DateTime.Now;
            }
    
    
    
    
        }
    }
