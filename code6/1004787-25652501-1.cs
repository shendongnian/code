    const string MODEL_FILE = "haarcascade_frontalface_alt.xml";
    FaceDetectionWinPhone.Detector m_detector;
    public MainPage()
    {
       InitializeComponent();
       m_detector = new FaceDetectionWinPhone.Detector(System.Xml.Linq.XDocument.Load(MODEL_FILE));
    }
    
    void photoChooserTask_Completed(object sender, PhotoResult e)
    {
        if (e.TaskResult == TaskResult.OK)  
        {
            BitmapImage bmp = new BitmapImage();
            bmp.SetSource(e.ChosenPhoto);
            WriteableBitmap btmMap = new WriteableBitmap(bmp);
     
            //find faces from the image
            List<FaceDetectionWinPhone.Rectangle> faces =
                 m_detector.getFaces(
                 btmMap, 10f, 1f, 0.05f, 1, false, false);
     
            //go through each face, and draw a red rectangle on top of it.
            foreach (var r in faces)
            {
                int x = Convert.ToInt32(r.X);
                int y = Convert.ToInt32(r.Y);
                int width = Convert.ToInt32(r.Width);
                int height = Convert.ToInt32(r.Height);
                btmMap.FillRectangle(x, y, x + height, y + width, System.Windows.Media.Colors.Red);
             }
            //update the bitmap before drawing it.
            btmMap.Invalidate();
            facesPic.Source = btmMap;
        }
    }
