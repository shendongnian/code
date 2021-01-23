    public interface IMyDynamicItem
    {
        string SomeItemName { get; set; }
        
        object this[int nFieldIndex] { get; set; }
        
        object this[string sFieldName] { get; set; }
        
        IList<string> FieldNames { get; }
    }
    
    public class MyDynamicItem : IMyDynamicItem
    {
        private Dictionary<string, object> m_oFields = 
            new Dictionary<string, object> ();
        
        public string SomeItemName { get; set; }
        
        public object this[int nFieldIndex]
        {
            get
            {
                string sFieldName = FieldNames[nFieldIndex];
                
                return ( m_oFields[sFieldName] );
            }
            set
            {
                string sFieldName = FieldNames[nFieldIndex];
                
                m_oFields[sFieldName] = value;
            }
        }
        
        public object this[string sFieldName]
        {
            get
            {
                return ( m_oFields[sFieldName] );
            }
            set
            {
                m_oFields[sFieldName] = value;
            }
        }
        
        public IList<string> FieldNames
        {
            get
            {
                return ( new List<string> ( m_oFields.Keys ) );
            }
        }
    }
