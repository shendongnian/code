        public MyDBContext(bool autoDetectChangesEnabled)
        : base("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\MyDB.mdf;User Instance=false;Integrated Security=True;MultipleActiveResultSets=True")
        {
            Initialize(autoDetectChangesEnabled);
        }
        public MyDBContext()
         : base("data source=(LOCAL)\\SQLEXPRESS;initial catalog=MyDB;persist security info=True;user id=user;password=pass;MultipleActiveResultSets=True;App=EntityFramework")
        {
            Initialize(true);
        }
