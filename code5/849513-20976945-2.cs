    public class NoPersitance : IPersistance {
        public void PersistData(MyData data) {
            // Nothing to do
        }
    }
    
    public class MySeviceData {
        private IPersistance _persistance;
    
        public MySeviceData(IPersistance persistance) {
            if (persistance == null)
                throw new ArgumentNullException("persistance");
    
            _persistance = persistance;
        }
    
        public MySeviceData() : this(new NoPersistance()) {
        }
        public MyData GetServiceData(Response reponseXML) {
            Debug.Assert(_persistance != null);
    
            MyData output = new MyData();
            // Fill your object's data
     
            // Store object somewhere
            _persistance.PersistData(output);
    
            return output;
        }
    }
