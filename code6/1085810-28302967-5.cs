    [Category("Behavior")]
    [Description("Gets or sets the type of data that will be compared")]
    [TypeConverter(typeof(DataTypeConverter))]
    [EditorAttribute(typeof(ValidatorTypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public ValidationDataType Type
    {
        get { return this.type; }
        set 
        { 
            this.type = value;
            if (this is RangeValidator)
            {
                this.SetRange();
            }
        }
    }
