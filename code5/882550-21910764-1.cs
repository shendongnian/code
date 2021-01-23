        private CustomDictionary _Dictio;
    
     public MainWindow()
            {
                Dictio = new CustomDictionary();
                this.DataContext = this;
                InitializeComponent();
            }
    
        public CustomDictionary Dictio
                {
                    get { return _Dictio; }
                    set { _Dictio = value; }
                }
        
        private void test(object sender, RoutedEventArgs e)
        {
        	foreach (KeyValuePair<int, object> kvp in Dictio)
                    {
                        Console.Out.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
        		}
        }
