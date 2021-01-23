        public static List<Cars> GetRegistrationCars(int registration)
        {
            List<Cars> registrationCars = new List<Cars>();
            using (var db = new EventsContext())
            {
                registrationCars = db.Cars.Where(c => c.RegistrationId == registration).ToList();
                return registrationCars.ToList();
            }
            // Here is too late - using has Disposed() the EventsContext() already so ToList will throw an exception
         }
