    public abstract class A : OriginalBaseClass
    {
        protected override void FilterByLetter(char a)
        {
            // Don't do anything
        }
    }
    
    public abstract class B : OriginalBaseClass
    {
        protected override void FilterByLetter(char a, char b)
        {
            // Don't do anything
        }
    }
    
    public class ClassThatNeedsOnlyTwoParameterOverload : A
    {
        protected override void FilterByLetter(char a, char b)
        {
            // Add necessary code
        }
    }
    
    public class ClassThatNeedsOnlyOneParameterOverload : B
    {
        protected override void FilterByLetter(char a)
        {
            // Add necessary code
        }
    }
