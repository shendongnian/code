    // This is the custom designer
    public class ScalingDesigner : ControlDesigner
    {
        public ScalingDesigner(){};
        // Say we want to correct the Size property
        public Size Size
        {
            get
            {
                // When the serializer asks for the value, give him the shadowed one
                return (Size)this.ShadowedProperties["Size"]
            }
            set
            {
                // When setting the value, assign the standard-DPI based value to the one the serializer would use
                this.ShadowedProperties["Size"] = value;
                // ... perform all the DPI scaling logic ...
                // Then assign a scaled value to the displayed control
                this.Control.Size = new Size(scaledWidth, scaledHeight)
            }
        }
        // Associate the shadowed values
        public override void PreFilterProperties(IDictionary properties)
        {
            base.PreFilterProperties(properties);
            properties["Size"] =
                TypeDescriptor.CreateProperty(
                    typeof(ScalingDesigner),
                    (PropertyDescriptor)properties["Size"],
                    new Attribute[0]);
        }
    }
    // ... and on your control ...
    [Designer(typeof(ScalingDesigner))]
    public class MyControl : Control
    {
        // ... whatever logic you want to implement ...
    }
