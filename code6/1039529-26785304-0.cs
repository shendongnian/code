    public class RubikTextBox : AbstractField, IAbstractField
    {
        public RubikTextBox(string val)
        {
            Value = val;
        }
        public static implicit operator string(RubikTextBox stringValue)
        {
            return stringValue.ToString();
        }
        public static implicit operator RubikTextBox(string stringValue)
        {
            return new RubikTextBox(stringValue);
        }
        public override string ToString()
        {
            return Value;
        }
    }
