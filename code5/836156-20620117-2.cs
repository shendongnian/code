    public class Querier
    {
        public static event Action Start;
        public static event Action Stop;
        public static event Action<int> ReportProgress;
        public static List<int> GetItems()
        {
            if (Start != null)
                App.Current.Dispatcher.BeginInvoke(Start,null);
            for (int index = 0; index <= 10; index++)
            {
                Thread.Sleep(200);
                if (ReportProgress != null)
                    App.Current.Dispatcher.BeginInvoke(ReportProgress, index*10);
            }
            if (Stop != null)
                App.Current.Dispatcher.BeginInvoke(Stop, null);
            return Enumerable.Range(1, 100).ToList();
        
        }
    
    }
