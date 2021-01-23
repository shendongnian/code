     public static List<Cars> GetRegistrationCars(int registration)
            {
                List<Cars> registrationCars = new List<Cars>();
                
                using (var db = new FerrariEventsContext())
                {
                    registrationCars = db.Cars.Include(m=> m.Model).Where(c => c.RegistrationId == registration).ToList();
                }
    
                return registrationCars;
            }
