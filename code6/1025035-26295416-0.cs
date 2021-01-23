    public Enum EType
    {
        A,
        B,
        C
    }
    public class Patient
    {
        public string Name { get; set; }
        public EType Type { get; set; }
        public int Value {get; set; }
    }
    public class PatientManager
    {
        private readonly List<Patient> _patients = new List<Patient>();
        
        
        public void AddPatient(string Name, EType Type, int Value)
        {
                var patient = new Patient
                    {
                        Name=Name,
                        Type=Type,
                        Value=Value
                    };
                _patients.Add(patient);
        }
    }
