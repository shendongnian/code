    public class Foo
    {
        public int? Id { get; set; }
        private Bar _bar;
        public virtual Bar 
        { 
            get { return _bar; }
            set
            {
                var entityFrameworkHack = this.Bar; //ensure the proxy has loaded
                _bar = value;
            }
        }
    }
