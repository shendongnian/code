    public class SearchCriteria
    {
        //prevent construction without using a factory method
        private SearchCriteria() { }
        public int? PatientId { get; private set; }
        public int? HospitalId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public static SearchCriteria CreatePatientSearch(
            int? patendId, int? hospitalId)
        {
            return new SearchCriteria()
            {
                PatientId = patendId,
                HospitalId = hospitalId
            };
        }
        public static SearchCriteria CreatePoliceSearch(
            int? patendId, int? hospitalId,
            string firstName, string lastName)
        {
            return new SearchCriteria()
            {
                PatientId = patendId,
                HospitalId = hospitalId,
                FirstName = firstName,
                LastName = lastName,
            };
        }
    }
