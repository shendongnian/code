    public interface IConditionalPropertySource
    {
        bool IsPropertyApplicable(string propertyName);
    }
    
    class Test : IConditionalPropertySource
    {
        public string SomeSetting { get; set; }
    
        public bool IsPropertyApplicable(string propertyName)
        {
            switch (propertyName)
            {
                case "SomeSetting":return DateTime.Now.DayOfWeek == DayOfWeek.Friday;
                default: return false;
            }
        }
    }
