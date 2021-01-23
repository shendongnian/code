    public partial class Form1 : Form {
        static TraceSource Trace1 { get; set; }
        static TraceSource Trace2 { get; set; }
        public Form1() {
            InitializeComponent();
            var listener = new TextBoxTraceListener();
            Trace1 = new TraceSource("Test1", SourceLevels.All);
            Trace1.Listeners.Add(listener);
            Trace2 = new TraceSource("Test2", SourceLevels.All);
            Trace2.Listeners.Add(listener);
        }
        protected override void OnLoad(System.EventArgs e) {
            base.OnLoad(e);
            Trace1.TraceInformation("hello1");
            Trace1.Flush();
            Trace2.TraceInformation("hello2");
            Trace2.Flush();
        }
    }
