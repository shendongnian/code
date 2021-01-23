    public class Clause : ClauseComponent
    {
        public int MyCustomPar1Id{ get; set; }
        [ForeignKey("MyCustomPar1Id")]
        public virtual Parameter Par1 { get; set; }       
    }
