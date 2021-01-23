    [ServiceContract]
    public class Lab_Lite_Service 
    {
        [OperationContract]
        public IEnumerable<Patient> GetPatients()
        {
            using (Lab_Lite_Entities db = new Lab_Lite_Entities())
            {
                // note the call of .ToList()
                // you need to materialize the enumerable that is returned, because it's not serializable
                return db.Patients.ToList();
            }
        }
    }
