    public class CustomNumericUpDown : NumericUpDown {
        static System.Reflection.FieldInfo currentValue;
        static CustomNumericUpDown() {
            currentValue = typeof(NumericUpDown).GetField("currentValue",
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
                    currentValue.SetValue(this, value);
                    UpdateEditText();
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
    
