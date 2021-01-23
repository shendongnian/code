    public class SomeControl : OriginalControl
    {
        static SomeControl()
        {
            OriginalControl.SomeProperty.OverrideMetadata(typeof(SomeControl), 
                new FrameworkPropertyMetadata(defaultValue, 
                FrameworkPropertyMetadata.OverridesInheritanceBehavior));
        }
    }
