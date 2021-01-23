    public class SomeClass
    {
        // This class and this constructor are externally visible
        // The parameter of type SomeOtherClass must also be public in order
        // for external assemblies to be able to construct this type
        public SomeClass(SomeOtherClass someOtherClass) { }
    }
    // This would cause the issue you are having since this type is private but
    // is included within a public contract (above), therefore the accessibility is 'inconsistent'
    private class SomeOtherClass { }
