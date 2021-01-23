    /// <summary>
    /// Extension method to get overpunch value
    /// </summary>
    /// <param name="number">the text to convert</param>
    /// <returns>int</returns>
    public static int OverpunchValue(this String number)
    {
        int returnValue;
        var ovpValue = OverPunchValues.Instance.OverPunchValueCollection.First(o => o.OverpunchCharacter ==
            Convert.ToChar(number.Substring(number.Length - 1)));
        returnValue = Convert.ToInt32(number.Substring(0, number.Length - 1) + ovpValue.NumericalValue.ToString());
        return ovpValue.IsNegative ? returnValue * -1 : returnValue;
    }
    /*singleton to store values */
    public class OverPunchValues
    {
        public List<OverPunchValue> OverPunchValueCollection { get; set; }
        private OverPunchValues()
        {
            OverPunchValueCollection = new List<OverPunchValue>();
            OverPunchValueCollection.Add(new OverPunchValue { OverpunchCharacter = '{', IsNegative = true, NumericalValue = 0 });
            OverPunchValueCollection.Add(new OverPunchValue { OverpunchCharacter = 'J', IsNegative = true, NumericalValue = 1 });
            //add the rest of the values here...
        }
        static readonly OverPunchValues _instance = new OverPunchValues();
        public static OverPunchValues Instance
        {
            get { return _instance; }
        }
    }
    public class OverPunchValue
    {
        public char OverpunchCharacter { get; set; }
        public bool IsNegative { get; set; }
        public int NumericalValue { get; set; }
           
        public OverPunchValue()
        {
        }            
    }
