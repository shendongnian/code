        public class DriversDAL
        {
            private RoadsoftDigitacV8DataContext db;
            public DriversDAL()
            {
                db = new RoadsoftDigitacV8DataContext();
            }
            public Driver GetDriver(int ID)
            {
                return db.Drives.Single(d => d.ID == ID);
            }
        }
