     string WorkingFolder = System.Configuration.ConfigurationManager.AppSettings["FolderPath"];
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = "abcdefghijklmnopqrstuvwxyz";
            System.IO.File.WriteAllText(WorkingFolder + @"\File1.txt", s);
        }
