        private CAMERACTRL CameraCtrl = null;
        //Add static for call from camera start , make sure this alive
        private static  Plustek_Camera.PFNCK_EVENT staticFnCamera ;
        public frmReadPassport()
        {
            InitializeComponent();
            staticFnCamera = fnPFNCK_EVENT;
        }
        Timer formClose = new Timer();
        private void frmReadPassport_Load(object sender, EventArgs e)
        {
            CaptureImages();
            formClose.Interval = 7000; // 7 sec
            formClose.Tick += new EventHandler(formClose_Tick);
            formClose.Start();
        }
        private void formClose_Tick(object sender, EventArgs e)
        {
            //free camera first
           // check if camera start then stop
            ReleaseResourceCamera();
            staticFnCamera =null;
            formClose.Stop();
            formClose.Tick -= new EventHandler(formClose_Tick);
            this.Dispose();
            this.Close();
        }    
       private void CaptureImages()
        {
            CameraCtrl = new CAMERACTRL();
            CameraCtrl.LoadCameraDll();
            CameraCtrl.GetDeviceList();
            String temp = CameraCtrl.GetParameter();
            CameraCtrl.Start(CameraCtrl.ScanMode,CameraCtrl.Resolution,CameraCtrl.ImageFormat, CameraCtrl.Alignment, staticFnCamera); 
       }
       public static bool fnPFNCK_EVENT(int iEvent, int iParam, IntPtr UserData)
       {
           captureImage();
           return true;
       }
    }
