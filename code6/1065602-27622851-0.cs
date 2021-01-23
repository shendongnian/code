    public abstract class BaseConversion
    {
        public abstract string VersionNumber { get; set; }
        public abstract string MethodToBeImplementedInEachDerivedClass();
        protected void MethodImplementedHereToBeUsedByDerivedClasses() 
        {
            // Implement common code here
        }
    }
    public class Schema147Conversion : BaseConversion
    {
        public override string VersionNumber { get { return "147"; } }
        public override string MethodToBeImplementedInEachDerivedClass()
        {
            return ""; // Implement schema specific code here... 
            // can use MethodImplementedHereToBeUsedByDerivedClasses() 
        }
    }
