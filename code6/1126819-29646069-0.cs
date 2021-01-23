        public MainWindow()
        {
            InitializeComponent();
            Names = new ObservableCollection<string>();
            DataContext = this;
            PopulateList("C:\names.txt");
        }
        public void PopulateList(string file)
        {
            string naam;
            string sourcepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string myfile = System.IO.Path.Combine(sourcepath, file);
            StreamReader reader = File.OpenText(myfile);
            naam = reader.ReadLine();
            while (naam != null)
            {
                Names.Add(naam);
                naam = reader.ReadLine();
            }
            reader.Close();
        }
