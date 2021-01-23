    public class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientGender { get; set; }
        public int WardId { get; set; }    //Add this
        public Ward Ward { get; set; }
    }
