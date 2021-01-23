    namespace MyDemo
    {
        public class FileService : IFileService
        {
            public FileService()
            {
            }
            public void WriteData(String data)
            {
                string filePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "Data.txt");
                System.IO.File.WriteAllText(filePath, data);
            }
            public String ReadData()
            {
                string filePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "Data.txt");
                var data = System.IO.File.ReadAllText(filePath);
                return data;
            }
        }
    }
