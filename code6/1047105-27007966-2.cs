    public class MyObject
    {
        public static int numFields = 20;
        public enum Conditions
        {
            C1, C2, C3, .... C20 //name for each condition, so can set values using descriptive names
        };
        public Boolean[] BinaryFields = new Boolean[numFields];
        public void setCondition(Conditions condition, Boolean value)
        {
            BinaryFields[(int)condition] = value;
        }
        public override string ToString()
        {
            return string.Join(",", BinaryFields);
        }
    }
