        public class GComboBox : ComboBox
        {
            public Type myType { get; set; }
            public GComboBox(Type type) { myType = type; }
            public GComboBox() { myType = typeof(int); }
            public override string ToString()
            {
                return myType.ToString();
            }
        }
