    public class FlowSettings
    {
        public bool IsVisible { get; set; }
        public bool Editable { get; set; }
        public bool Revisable { get; set; }
        public int TblId { get; set; }
    }
    
    private bool ParseBool(string value)
    {
        return Convert.ToBoolean(EmptyToFalse(value));
    }
    
    private int ParseInt(string value)
    {
        return Convert.ToInt32(EmptyToInvalid(value));
    }
    
    private string EmptyToFalse(string value)
    {
        return string.IsNullOrWhiteSpace(value) ? bool.FalseString : value;
    }
    
    private string EmptyToInvalid(string value)
    {
        return string.IsNullOrWhiteSpace(value) ? "-1" : value;
    }
