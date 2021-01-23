    public class SerializeFileHandler
    {  
        private readonly IFileStreamSource _source;
        public SerializeFileHandler(IFileStreamSource source)
        {
            _source = source;
        }
        public void WriteListToFile(MyProject myProject, string filePath)
        {
            using (var stream = _source.Open(filePath, FileMode.Create, FileAccess.Write)
            {
                BinaryFormatter bFormatter = new BinaryFormatter();
                bFormatter.Serialize(stream, myProject);
            }
        }
    
        public MyProject ReadListFromFile(String filePath)
        {
            MyProject myProject = null;
            using (var stream = _source.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter bFormatter = new BinaryFormatter(); 
           
                // Obtain objects from file via serialization
                myProject = (MyProject)bFormatter.Deserialize(stream);
            }
            return myProject;
         }
    }
