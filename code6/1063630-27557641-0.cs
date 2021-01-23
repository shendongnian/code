    void Main()
    {
    	var Plans = new List<Plan>();
    	Plans.Add(new Plan() {PatientId = 1, PlanName = "Good Plan"});
    	Plans.Add(new Plan() {PatientId = 2, PlanName = "Bad Plan"});
    	var Patients = new List<Patient>();
    	Patients.Add(new Patient() {ClinicId = 1, Name = "Frank"});
    	Patients.Add(new Patient() {ClinicId = 2, Name = "Fort"});
       // This is your LINQ    	
       var patientList = from p in Patients
                         where p.ClinicId == 1
           select p.ClinicId;
       var patientswithplan = from p in Plans
           where patientList.Contains(p.PatientId)
           select p;
       Console.WriteLine(patientswithplan);
       // We return a PLAN here
       // Result
       // IEnumerable<Plan> (1 item) 
       // PatientId 1
       // PlanName  Good Plan
    
       // This is the equivalent Linq of your SQL    
       var myPatient = Patients.Where(
                               pa => pa.ClinicId == 1 && 
                               Plans.Any(pl => pl.PatientId == pa.ClinicId)
                                     );
       Console.WriteLine(myPatient);
       // Look! We return a PATIENT here
       // Result
       // IEnumerable<Patient> (1 item) 
       // ClinicId  1
       // Name      Frank
    }
    
    // Define other methods and classes here
    class Patient
    {
    	public Patient() {}
    	public int ClinicId { get; set; }
    	public string Name { get; set; }
    }
    
    class Plan
    {
       public Plan() {}
       public int PatientId { get; set; }
       public string PlanName { get; set; }   
    }
