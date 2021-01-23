        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            string deployDir = AppDomain.CurrentDomain.BaseDirectory;
            string[] rows = deployDir.Split(new string[] { "TestResults" }, StringSplitOptions.None);
            string projectPath = rows[0].ToString();
            _path = projectPath + "newpath\\";
        }
