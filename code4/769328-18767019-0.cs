    class LoadImageFromDbSpike
    {
        private const string ConnectionString = @"Data Source=[SERVERNAME];Initial Catalog=[DBNAME];Trusted_Connection=true;Connect Timeout=180;";
        private const string ImageOnDiskPath = @"c:\test.png";
        private const string OutputPath = @"c:\output.png";
        static void Main(string[] args)
        {
            var imageData = File.ReadAllBytes(ImageOnDiskPath);
            
            var imageId = StoreImageData(imageData);
            var imageDataFromDb = LoadImageData(imageId);
            File.WriteAllBytes(OutputPath, imageDataFromDb);
        }
        private static int StoreImageData(IEnumerable<byte> imageData)
        {
            const string insertCommand = "INSERT INTO ImageSpike (Image) " +
                                         "VALUES (@ImageData); " +
                                         "SELECT SCOPE_IDENTITY();";
            using (var con = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(insertCommand, con))
            {
                cmd.Parameters.AddWithValue("@ImageData", imageData);
                cmd.Connection.Open();
                return (int) (decimal) cmd.ExecuteScalar();
            }
        }
        private static byte[] LoadImageData(int id)
        {
            const string loadImageCommand = "SELECT TOP 1 Image FROM ImageSpike " +
                                            "WHERE Id = @Id; ";
            using (var con = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(loadImageCommand, con))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Connection.Open();
                var result = cmd.ExecuteScalar();
                return (byte[]) result;
            }
        }
    }
