    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            ChartValues = Enumerable.Range(1, 10) //replace this with your histogram
                .Select(i => (float) i*i)
                .ToArray();
        }
        public float[] ChartValues { get; set; }
    }
