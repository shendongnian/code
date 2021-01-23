        XmlDataProvider bookData;
        public BookPage()
        {
            InitializeComponent();
            string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            bookData = (XmlDataProvider)this.Resources["bookData"];
            bookData.Source = new Uri(appPath + @"\SNG.xml");
        }
