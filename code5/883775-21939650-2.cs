    var jsonobject = JsonConvert.DeserializeObject<RootObject>(json);
    public class Patient
    {
        public string patientid { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string start { get; set; }
        public string last { get; set; }
        public string engagement { get; set; }
        public string drug { get; set; }
        public string adherence { get; set; }
        public string vitals { get; set; }
        public string last_appointment { get; set; }
        public string next_appointment { get; set; }
    }
    public class Patients
    {
        public List<Patient> patient { get; set; }
    }
    public class Pathway
    {
        public Patients patients { get; set; }
    }
    public class RootObject
    {
        public Pathway pathway { get; set; }
    }
