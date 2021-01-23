    public partial class test : UserControl
    {
        public string IPadd { get; set; }
        public string usrID { get; set; }
        public string pswd { get; set; }
        public string filename { get; set; }
        public FileStream ws { get; set; }
        public test()
        {
            InitializeComponent();
        }
        public test(string Ip, string Id, string Pass, string file, FileStream stream )
        {
            InitializeComponent();
            IPadd = Ip;
            usrID = Id;
            pswd = Pass;
            filename = file;
            ws = stream;
            JPEGStream jpegSource1 = new JPEGStream("http://" + IPadd + "/jpg/image.jpg?resolution=320x240");
            jpegSource1.Login = usrID;
            jpegSource1.Password = pswd;
            jpegSource1.NewFrame += new NewFrameEventHandler(jpegSource1_NewFrame);
            source1.VideoSourceError += new VideoSourceErrorEventHandler(source1_VideoSourceError);
            pegSource1.VideoSourceError += new VideoSourceErrorEventHandler(jpegSource1_VideoSourceError);
            Player1.VideoSource = jpegSource1;
        }
    }
