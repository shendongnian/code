    public class SubClass : BaseClass
    {
        public SubClass()
        {
            Build = "Hello"; // Build must be either public or protected in the base class.
            // SubClass inherits Build, therfore no "base." is required.
        }
        // Other methods to go here
    }
