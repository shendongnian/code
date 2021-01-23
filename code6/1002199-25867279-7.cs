        public ObservableCollection<Lista> lista;
        private RelayCommand cmd;
        public RelayCommand Cmd
        {
            get { return cmd ?? (cmd = new RelayCommand(new Action<object>(AddRow))); }
        }
        public MainWindow()
        {
            lista = new ObservableCollection<Lista>() { new Lista() { Text_nr1 = "test", Text_nr1_background="green", Text_nr2_background="red",Text_nr2 = "test2" } };
            InitializeComponent();
            this.DataContext = this;
        }
        void AddRow(object obj)
        {
            int numer;
            Int32.TryParse(obj.ToString(), out numer);
            lista.Insert(numer, new Lista() { Text_nr1 = "test", Text_nr1_background = "green", Text_nr2_background = "red", Text_nr2 = "test2" });
        }
