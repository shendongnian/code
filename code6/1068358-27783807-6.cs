    [Serializable]
    public class ValidationItem: Component
    {
        [DefaultValue("")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string DisplayName { get; set; }
        [DefaultValue(-1)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int Value { get; set; }
        public event ValidatingEventHandler Validating;
        public delegate void ValidatingEventHandler(object sender, EventArgs e);
        public ValidationItem() 
        {
            Name = "New Item";
            Value = 0;
        }
    }   
