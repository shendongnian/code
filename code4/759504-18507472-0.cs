        public class DirversDAL
        {
            private RoadsoftDigitacV8DataContext db;
            public DirversDAL()
            {
                db = new RoadsoftDigitacV8DataContext();
            }
            public Driver GetDriver(int ID)
            {
                return db.Drives.Single(d => d.ID == ID);
            }
        }
