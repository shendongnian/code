    public Enum EType
    {
        A,
        B,
        C
    }
    public class PatientData
    {
        public EType Type { get; set; }
        public int Value {get; set; }
    }
    public class PatientManager
    {
        private readonly Dictionary<String, List<PatientData>> _patients = new Dictionary<String, List<PatientData>>();
        
        
        public void AddPatientData(string name, EType type, int value)
        {
                var patientData = new PatientData
                    {
                        Type = type,
                        Value = value
                    };
                List<PatientData> patientDatas;
                if (!dictionary.TryGetValue(name, out patientDatas))
                {
                    patientDatas = new List<PatientData>();
                    dictionary.Add(key, patientDatas);
                }
                _patientDatas.Add(patientData);
        }
    }
