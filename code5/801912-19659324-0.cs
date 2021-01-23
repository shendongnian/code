    public class CustomNumericUpDown : NumericUpDown {
        static System.Reflection.FieldInfo onValueChanged;
        static CustomNumericUpDown() {
            onValueChanged = typeof(NumericUpDown).GetField("onValueChanged",
                                 System.Reflection.BindingFlags.NonPublic | 
                                 System.Reflection.BindingFlags.Instance);
        }
        public CustomNumericUpDown() {
            RaiseValueChangedOnlyByUser = true;
        }
        public bool RaiseValueChangedOnlyByUser { get; set; }
        public new decimal Value {
            get { return base.Value; }
            set
            {
                if (RaiseValueChangedOnlyByUser){
                    object currentHandler = onValueChanged.GetValue(this);
                    onValueChanged.SetValue(this, null);
                    base.Value = value;
                    onValueChanged.SetValue(this, currentHandler);
                }
                else base.Value = value;
            }
        }
    }
    //Then in your code just use the `Value` normally, it won't
    //never fire the ValueChanged event unless user changes it via the UI
    //You can set the RaiseValueChangedOnlyByUser to false to 
    //enable firing ValueChanged when the value is changed by code (like as 
    //the standard NumericUpDown does)
    
