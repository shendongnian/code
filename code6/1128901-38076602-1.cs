    public class PatientController : ApiController
    {
        private readonly IMongoCollection<Patient> _patients;
        public PatientController()
        {
            _patients = PatientDb.Open();
        }
        public IEnumerable<Patient> Get()
        {
            return _patients.Find(new BsonDocument()).ToEnumerable();
        }
    }
