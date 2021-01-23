    [Cmdlet(VerbsCommon.Get, "ExampleCommand")]
    public class GetSolarLunarName : PSCmdlet
    {   
        [Parameter(Position = 0, ValueFromPipeline = true, Mandatory = true)]
        [ValidateDateTime()]
        public DateTime UtcDateTime { get; set; }
        protected override void ProcessRecord()
        {
            
            var ExampleOutput = //Your code
            this.WriteObject(ExampleOutput);
            base.EndProcessing();
        }
    }
    class ValidateDateTime:ValidateArgumentsAttribute {
    protected override void Validate(object arguments,EngineIntrinsics engineIntrinsics) {
        var date = (DateTime)arguments;
        if( date.Year < 1700 || date.Year > 2082){
            throw new ArgumentOutOfRangeException();
        }
        
    }
