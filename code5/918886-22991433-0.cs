    public partial class Form1 : Form
    {
        private const int PollIntervalMilliseconds = 100;
        private readonly Task _backgroundPoll;
        public Form1()
        {
            InititalizeComponents();
            _backgroundPoll = StartBackgroundPoll();
        }
        
        private Task StartBackgroundPoll()
        {
            return Observable
                .Interval(TimeSpan.FromMilliseconds(PollIntervalMilliseconds))
                .Select(_ => GetData())
                .ObserveOn(gdvGrid)
                .ForEachAsync(data => gdvGrid.Rows.Add(data));
        }
    }
