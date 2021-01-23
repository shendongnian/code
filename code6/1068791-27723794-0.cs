     public class ItemDisplay<TValue>
     {
         private readonly string m_displayText;
    
         public ItemDisplay(TValue value, String displayText)
        {
            this.Value = value;
            m_displayText = displayText;
        }
        public TValue Value { get; set; }
        public override string ToString()
        {
            return m_displayText;
        }
    }
