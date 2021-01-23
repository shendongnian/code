    public class Course
    {
        private string _formalDate; // <-- this is a backing field;
        
        // and this property uses the backing field to read/store data
        public string FormalDate 
        { 
            get { return _formalDate; } 
            set { _formalDate = convertFormalDateToSpanish(value); } 
        }
    }
    
