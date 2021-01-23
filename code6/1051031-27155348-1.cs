    [TestFixture, RequiresSTA]
    public class BindingTests
    {
        [Test]
        public void T1_BindingErrorsExpected()
        {
            string error = null;
            using (var listener = new ObservableTraceListener())
            {
                listener.TraceCatched += s => error = s;
                //TextBlock myText = new TextBlock();
                //UserControl control = new UserControl();
                //Binding myBinding = new Binding("BadBinding");
                //myBinding.Source = control;
                //myText.SetBinding(TextBlock.BackgroundProperty, myBinding);
                PresentationTraceSources.DataBindingSource.TraceEvent(TraceEventType.Error,0, "Hello World!");    
            }
            Assert.IsNotNull(error);
            Console.WriteLine(error);
            
        }
    }
    public sealed class ObservableTraceListener : TraceListener
    {
        private readonly StringBuilder _Builder = new StringBuilder();
        public ObservableTraceListener()
        {
            //PresentationTraceListener.Add(SourceLevels.Error, this);
        }
        protected override void Dispose(bool disposing)
        {
            Flush();
            Close();
            //PresentationTraceListener.Remove(this);
        }
        public override void Write(string message)
        {
            _Builder.Append(message);
        }
        public override void WriteLine(string message)
        {
            Write(message);
            if (TraceCatched != null)
                TraceCatched(_Builder.ToString());
            _Builder.Clear();
        }
        public event Action<string> TraceCatched;
    }
