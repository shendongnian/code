        public static void MyDispose(ref DbContext db)
        {
            if (db != null)
            {
                db.Dispose();
                db = null;
            }
        }
