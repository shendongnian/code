    public partial class Form1 : Form
    {
        IDisposable subscription;
        IObservable<long> sequence;
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            if (subscription != null)
                subscription.Dispose();
    
            sequence = Observable
                .Interval(TimeSpan.FromMilliseconds(1))
                .Take(10000); // generate a timed sequence change
    
            subscription = sequence // act upon the sequence
                .ObserveOn(SynchronizationContext.Current)
                .Subscribe(x => label1.Text = x.ToString());
        }
    }
