    public class AuditTrail 
    {
        private object[] _myObjectVariableList;
    
        public object[] MyObjectVariableList
        {
            get { return _myObjectVariableList; }
            set { _myObjectVariableList = value; }
        }
        public AuditTrail()
        {
            MyObjectVariableList= new object[7];
        }
    }
