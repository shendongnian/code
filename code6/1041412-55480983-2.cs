    public class DataRecord
    {
        [Name("Time of Day")]
        public string TimeOfDay { get; set; }
    
        [Name("Process Name")]
        public string ProcessName { get; set; }
    
        public string PID { get; set; }
        public string Operation { get; set; }
        public string Path { get; set; }
        public string Result { get; set; }
        public string Detail { get; set; }
    
        [Name("Image Path")]
        public string ImagePath { get; set; }
    
        public static IEnumerable<DataRecord> ParseDataRecords(Stream file)
        {
            using (var sr = new StreamReader(file))
            using (var csv = new CsvReader(sr))
            {
                foreach (var record in csv.GetRecords<DataRecord>())
                {
                    yield return record;
                }
            }
        }
    }
