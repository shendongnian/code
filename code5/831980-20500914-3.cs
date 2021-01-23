    public class YourModel {
        // This is the property tied to your checkbox
        public bool YourBooleanProperty { get; set; }
        [RequiredIf("YourBooleanProperty", true)]
        public string Item { get; set; }
    }
