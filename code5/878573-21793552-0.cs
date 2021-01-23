    public interface IDataChangeHandler
    {
        void OnDataChanged(object data, string tag);
    }
    
    public class DataObject : IDataChangeHandler
    {
        private string _property1;
        public string Property1
        {
            get { return _property1; }
            set
            {
                _property1 = value;
                OnDataChanged(_property1, "property1");
            }
        }
    
        private int _property2;
        public int Property2
        {
            get { return _property2; }
            set
            {
                _property2 = value;
                OnDataChanged(_property2, "property2");
            }
        }
    
    
        public void OnDataChanged(object data, string tag)
        {
            /*write the changes in xml*/
        }
    }
