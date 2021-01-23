    [NotifyPropertyChanged]
    public class TestClass : INotifyPropertyChanged
    {
        public int Property1 { get; set; }
        public int Property2 { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void DoSomething()
        {
            this.Property1 = 42;
            this.OnPropertyChanged( "Property2" );
        }
        protected void OnPropertyChanged( string propertyName )
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if ( handler != null )
                handler( this, new PropertyChangedEventArgs(propertyName) );
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TestClass test = new TestClass();
            INotifyPropertyChanged inpc = Post.Cast<TestClass, INotifyPropertyChanged>(test);
            inpc.PropertyChanged += ( s, ea ) =>
            {
                Console.WriteLine("Notification received for {0}", ea.PropertyName);
            };
            test.DoSomething();
        }
    }
