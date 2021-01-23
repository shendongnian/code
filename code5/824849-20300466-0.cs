    public class ID
    {
        public string id {get; set; }
        public string UserName {get; set; }
        public string Password {get; set; }        
        public string Bla1 {get; set; }
        public string Bla2 {get; set; }
    }
    public IList<ID> GetAllID()
    {
        string folderName = @"c:\IDFolder";
        string fileName = "ID0";
        string formatFile = ".txt";
        IList<ID> IDs = new List<ID>();
        for (int i = 0; i < 9; i++)
        {
            string indexFile = (i + 1).ToString();
            string filePath = folderName + "\\" + fileName + indexFile + formatFile;
            if (File.Exists(filePath))
            {
                string[] result = File.ReadAllLines(filePath);
                ID id = new ID();
                id.id = result[0];
                id.UserName = result[1];
                id.Password = result[2];
                id.Bla1 = result[3];
                id.Bla2 = result[4];
                // add id into IDs
                IDs.Add(id);
            }
         }
         return IDs;
    }
    
