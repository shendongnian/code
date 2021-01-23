    /*
    ** In your custom control class
    */
    
    using Microsoft.Windows.Design.Features;
    // ...
    
    [Feature(typeof(CustomTextBoxDefaults))]
    public class CustomTextBox : TextBox
    {
        /* ... */
    }
    
    /*
    ** CustomTextBoxDefaults provides default values for designer
    */
    
    using Microsoft.Windows.Design.Model;
    // ...
    
    class CustomTextBoxDefaults : DefaultInitializer
    {
        public override void InitializeDefaults(ModelItem item)
        {
            item.Properties["Width"].SetValue(120);
            // Setup other properties
        }
    }
