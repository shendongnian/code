    public class DataHolder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static DataHolder InitRandom()
        {
            var random = new Random();
            return new DataHolder() {Id = random.Next(), Name = random.Next().ToString()};
        }
    }
    public class OneThread
    {
        public static readonly OneThread Instance = new OneThread();
        public OneThread()
        {
            Data = DataHolder.InitRandom();
        }
        public DataHolder Data;
        // this method is called often by one thread
        public void RunsEverySecond()
        {
            Data = DataHolder.InitRandom();
        }
    }
    public class MultiThread
    {
        public static List<string> Results = new List<string>(); 
        // called externaly by multiple threads
        public static bool SomeMethod()
        {
            var loc = OneThread.Instance.Data;
            // initializing new Random every time on purpose since that also takes time
            Thread.Sleep(new Random().Next(0,3));
            var id = loc.Id;
            var name = loc.Name;
            var res = loc.Id == id && loc.Name == name;
            if (!res)
                throw new Exception("different");
            var log = String.Format("{0} - OneThreadId: {1}, loc.Id: {2}, id: {3}", res, OneThread.Instance.Data.Id,
                loc.Id, id);
            lock (Results)
            {
                Results.Add(log);
            }
            return res;
        }
        public static void SpitResults()
        {
            File.WriteAllLines("C:\\res.txt", Results);
        }
    }
