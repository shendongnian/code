    public class CaseB : Case {
        public int ReferenceId { get; set; }
        public virtual Reference Reference { get; set; } // <- "virtual" here is important!
        protected override bool IsComplete() {
            return Reference.Name == "Tallmaris"; // <- at this point the EF 
                                                  // will load the Reference.
        }
    }
