        public MainWindow()
        {
            InitializeComponent();
            webb = new WebBrowser();
            webb.Visibility = System.Windows.Visibility.Hidden;
            root.Children.Add(webb);
            webb.LoadCompleted += webb_LoadCompleted;
            webb.Navigate("http://www.google.com");
        }
        void webb_LoadCompleted(object sender, NavigationEventArgs e)
        {
            MessageBox.Show("Completed loading the page");
            mshtml.HTMLDocument doc = webb.Document as mshtml.HTMLDocument;
            mshtml.HTMLInputElement obj = doc.getElementById("gs_taif0") as mshtml.HTMLInputElement;
            mshtml.HTMLFormElement form = doc.forms.item(Type.Missing, 0) as mshtml.HTMLFormElement;
            webb.LoadCompleted -= webb_LoadCompleted; //REMOVE THE OLD EVENT METHOD BINDING
            webb.LoadCompleted += webb_LoadCompleted2; //BIND TO A NEW METHOD FOR THE EVENT
            obj.value = "test search";
            form.submit(); //PERFORM THE POST ON THE FORM OR SEARCH
        }
        //SECOND EVENT TO FIRE AFTER YOU POST INFORMATION
        void webb_LoadCompleted2(object sender, NavigationEventArgs e)
        {
            MessageBox.Show("Completed loading the page second time after post"); 
        }
