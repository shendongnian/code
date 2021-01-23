    public class FileData
    {
        public int Year {get;set;}
        public int Day  {get;set;}
        public int Month  {get;set;}
        public int Hour  {get;set;}
        public int Minute  {get;set;}
        public int Called  {get;set;}
        public int Calling  {get;set;}
        public FileData(string[] parsedInfo)
        {
            Year = Convert.ToInt32(parsedInfo[0]);
            // and so on with other member to load
        }
    }
