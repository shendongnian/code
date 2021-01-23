    class SubPropertyDescriptor : PropertyDescriptor
    {
        private PropertyDescriptor _parent;
        private PropertyDescriptor _child;
        public SubPropertyDescriptor(PropertyDescriptor parent, PropertyDescriptor child, string propertyDescriptorName)
            : base(propertyDescriptorName, null)
        {
            _child = child;
            _parent = parent;
        }
        //in this example I have made this read-only, but you can set this to false to allow two-way data-binding
        public override bool IsReadOnly{ get { return true; } }
        public override void ResetValue(object component)  { }
        public override bool CanResetValue(object component){ return false; }
        public override bool ShouldSerializeValue(object component){ return true;}
        public override Type ComponentType{ get { return _parent.ComponentType; } }
        public override Type PropertyType{ get { return _child.PropertyType; } }
        //this is how the value for the property 'described' is accessed
        public override object GetValue(object component)
        {
            return _child.GetValue(_parent.GetValue(component));
        }
        /*My example has the read-only value set to true, so a full implementation of the SetValue() function is not necessary.  
        However, for two-day binding this must be fully implemented similar to the above method. */
        public override void SetValue(object component, object value)
        {
            //READ ONLY
            /*Example:  _child.SetValue(_parent.GetValue(component), value);
              Add any event fires or other additional functions here to handle a data update*/
        }
    }
